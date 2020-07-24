using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using DisplayInfoHelper.MSSQL;
using DisplayInfoHelper.Models;
using System.Reflection;
using System.Data.Entity;

namespace DisplayInfoHelper
{
    public class DisplayInfoHelper
    {
        public static string[] FieldDefaults = { "MaterialCode", "MaterialName", "SellPrice" };
        /// <summary>
        /// Hàm lưu một đối tượng cần phải thiết lập một cách hiện thị mới
        /// </summary>
        public static ConfigDisplayInfo SaveConfigDisplayInfoData(ConfigDisplayInfoModel model, out string sMessage)
        {
            sMessage = "";
            var returnData = new ConfigDisplayInfo();
            try
            {
                using (var db = new Ajuma_devEntities())
                {
                    var dataTable = db.ConfigDisplayInfoes.ToList();
                    returnData = dataTable.Where(c => c.Entity == model.Entity && c.ScreenCode == model.ScreenCode && c.UserType == model.UserType).FirstOrDefault();
                    if (returnData == null)
                    {
                        returnData = db.ConfigDisplayInfoes.Add(new ConfigDisplayInfo()
                        {
                            Entity = model.Entity,
                            ScreenCode = model.ScreenCode,
                            UserType = model.UserType
                        });
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                sMessage = ex.Message;
            }
            return returnData;
        }

        /// <summary>
        /// Hàm lấy đối tượng được thiết lập hiện thị đặc biệt
        /// </summary>
        public static ConfigDisplayInfo GetConfigDisplayInfoData(ConfigDisplayInfoModel model, out string sMessage)
        {
            sMessage = "";
            var returnData = new ConfigDisplayInfo();
            try
            {
                using (var db = new Ajuma_devEntities())
                {
                    var dataTable = db.ConfigDisplayInfoes.ToList();
                    returnData = dataTable.Where(c => c.Entity == model.Entity && c.ScreenCode == model.ScreenCode && c.UserType == model.UserType).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                sMessage = ex.Message;
            }
            return returnData;
        }
        public static ConfigDisplayInfoDetail GetConfigDisplayInfoDetailData(long ConfigDisplayInfoId, out string sMessage)
        {
            sMessage = "";
            var returnData = new ConfigDisplayInfoDetail();
            try
            {
                using (var db = new Ajuma_devEntities())
                {
                    var dataTable = db.ConfigDisplayInfoDetails.ToList();
                    returnData = dataTable.Where(c => c.ConfigDisplayInfoId == ConfigDisplayInfoId).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                sMessage = ex.Message;
            }
            return returnData;
        }
        public static ConfigDisplayInfoDetail UpdateConfigDisplayInfoDetail(Ajuma_devEntities db, ConfigDisplayInfoDetailModel data)
        {
            var ConfigDisplayInfoId = Convert.ToInt64(data.ConfigDisplayInfoId);
            var dataOld = db.ConfigDisplayInfoDetails.Where(c => c.ConfigDisplayInfoId == ConfigDisplayInfoId).FirstOrDefault();
            if (dataOld != null)
            {
                dataOld.fConvert = data.fConvert;
                dataOld.Fields = data.Fields;
            }
            db.SaveChanges();
            return dataOld;
        }
        public static ConfigDisplayInfoDetail InsertConfigDisplayInfoDetail(Ajuma_devEntities db, ConfigDisplayInfoDetail data)
        {
            var newData = db.ConfigDisplayInfoDetails.Add(data);
            db.SaveChanges();
            return newData;
        }
        public static ConfigDisplayInfoDetail InsertOrUpdateDisplayInfoDetail(ConfigDisplayInfoDetailModel data, out string sMessage)
        {
            sMessage = "";
            ConfigDisplayInfoDetail returnData = new ConfigDisplayInfoDetail();
            try
            {
                using (var db = new Ajuma_devEntities())
                {
                    var ConfigDisplayInfoId = Convert.ToInt64(data.ConfigDisplayInfoId);
                    returnData = UpdateConfigDisplayInfoDetail(db, data);
                    if (returnData == null)
                    {
                        returnData = new ConfigDisplayInfoDetail()
                        {
                            ConfigDisplayInfoId = ConfigDisplayInfoId,
                            fConvert = data.fConvert,
                            Fields = data.Fields
                        };
                        returnData = InsertConfigDisplayInfoDetail(db, returnData);
                    }
                }
            }
            catch (Exception ex)
            {
                sMessage = ex.Message;
            }
            return returnData;
        }
        public static Dictionary<string, string> GetDisplayName(ConfigDisplayInfoModel model, out string sMessage)
        {
            sMessage = "";
            var result = new Dictionary<string, string>();
            try
            {
                var data = GetConfigDisplayInfoData(model, out sMessage);
                string[] fields = { };
                if (data == null)
                {
                    fields = FieldDefaults;
                }
                else
                {
                    var dataDetail = GetConfigDisplayInfoDetailData(data.Id, out sMessage);
                    if (dataDetail == null) fields = FieldDefaults;
                    else
                    {
                        fields = JsonConvert.DeserializeObject<FieldsModel>(dataDetail.Fields).fields;
                    }
                }
                Console.OutputEncoding = Encoding.UTF8;
                using (var db = new Ajuma_devEntities())
                {
                    var dbSet = GetDbSetByName(db, data.Entity, out sMessage);
                    foreach (var sItem in dbSet)
                    {
                        string displayName = string.Empty;
                        foreach (var field in fields)
                        {
                            var propertyInfo = sItem.GetType().GetProperty(field);
                            if (propertyInfo != null)
                            {
                                displayName += propertyInfo.GetValue(sItem) + " - ";
                            }
                        }
                        var Id = sItem.GetType().GetProperty("Id").GetValue(sItem).ToString();
                        result.Add(Id, displayName);
                        Console.WriteLine(displayName);
                    }
                }
            }
            catch (Exception ex)
            {
                if (sMessage == "") sMessage = ex.Message;
            }
            return result;
        }
        public static DbSet GetDbSetByName(Ajuma_devEntities db, string DbSetName, out string sMessage)
        {
            sMessage = string.Empty;
            var type = Assembly.GetExecutingAssembly()
                    .GetTypes()
                    .FirstOrDefault(t => t.Name == DbSetName);
            var temp = Assembly.GetExecutingAssembly().GetTypes();
            var test = new DisplayInfoHelper();
            Type tt = test.GetType();
            if (type != null)
            {
                DbSet dbSet = db.Set(type);
                return dbSet;
            }
            else
            {
                sMessage = "Không có DbSet nào có tên là " + DbSetName + " trong Entities";
                return null;
            }
        }
        static void Main(string[] args)
        {
            // Phần này dùng để insert, update cho một entity, screen và user
            string jsonString = File.ReadAllText(@"D:\www\DisplayInfoHelper\Input\Input_1.json");
            var dataInput = JsonConvert.DeserializeObject<ConfigDisplayInfoModel>(jsonString);
            string sMessage = string.Empty;
            var data = GetConfigDisplayInfoData(dataInput, out sMessage);
            if (data == null) data = SaveConfigDisplayInfoData(dataInput, out sMessage);
            var dataConfigDisplayInfoDetail = new ConfigDisplayInfoDetailModel()
            {
                ConfigDisplayInfoId = data.Id.ToString(),
                fConvert = "hihi",
                Fields = File.ReadAllText(@"D:\www\DisplayInfoHelper\Input\Fields_1.json")
            };
            InsertOrUpdateDisplayInfoDetail(dataConfigDisplayInfoDetail, out sMessage);
            // Phần này đi lấy tên hiện thị
            var model = new ConfigDisplayInfoModel()
            {
                Entity = data.Entity,
                ScreenCode = "1",
                UserType = data.UserType
            };
            var DisplayName = GetDisplayName(model, out sMessage);
            Console.WriteLine(sMessage);
            Console.ReadLine();
        }
    }
}
