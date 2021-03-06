//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DisplayInfoHelper.MSSQL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Supplier
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Supplier()
        {
            this.Materials = new HashSet<Material>();
        }
    
        public long SupplierId { get; set; }
        public string SupplierCode { get; set; }
        public string SupplierName { get; set; }
        public string SupplierName_UnSign { get; set; }
        public string SupplierShortName { get; set; }
        public string SupplierEmployerName { get; set; }
        public string SupplierEmployerPhone { get; set; }
        public string SupplierEmployerEmail { get; set; }
        public string Address { get; set; }
        public string TaxCode { get; set; }
        public string Trade { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string AccountBank { get; set; }
        public long Bank { get; set; }
        public long TypeId { get; set; }
        public string AccDebit { get; set; }
        public decimal DebtNorm { get; set; }
        public string Note { get; set; }
        public bool InValid { get; set; }
        public bool Disable { get; set; }
        public byte[] TimeStamp { get; set; }
        public byte[] TimeStampCode { get; set; }
        public string ClientCode { get; set; }
        public string SyncCode { get; set; }
        public string VisibleBit { get; set; }
        public decimal DebitLimit { get; set; }
        public int SumOffDebitDay { get; set; }
        public Nullable<System.DateTime> BirthDay { get; set; }
        public string NumberOfContracts { get; set; }
        public Nullable<long> FirstRevenue { get; set; }
        public Nullable<System.DateTime> ContractDate { get; set; }
        public string CMND { get; set; }
        public long FormOfPayment { get; set; }
        public int StatusSupplier { get; set; }
        public System.DateTime ContractEndDate { get; set; }
        public bool IsShip { get; set; }
        public decimal PhanTramCKDungHanTT { get; set; }
        public decimal PhanTramPhatTraCham { get; set; }
        public decimal PhanTramCKMuaHang { get; set; }
        public decimal HanMucTinDung { get; set; }
        public decimal TargetNam { get; set; }
        public decimal ThuongNam { get; set; }
        public decimal TargetQuy { get; set; }
        public decimal ThuongQuy { get; set; }
        public string CKGoiHang { get; set; }
        public string HoTroTrungBay { get; set; }
        public decimal HoTroMarKeting { get; set; }
        public long AutoLogOnCode_LastUpdate_ById { get; set; }
        public string AutoLogOnCode_LastUpdate_ByFullName { get; set; }
        public Nullable<System.DateTime> AutoLogOnCode_LastUpdate_DateTime { get; set; }
        public string AutoLogOnCode_LastUpdate_IP { get; set; }
        public string AutoLogOnCode_LastUpdate_ComputerName { get; set; }
        public string AutoLogOnCode_LastUpdate_MACAddress { get; set; }
        public Nullable<long> ProvinceId { get; set; }
        public string ProvinceName { get; set; }
        public Nullable<long> DistrictId { get; set; }
        public string DistrictName { get; set; }
        public Nullable<long> WardId { get; set; }
        public string WardName { get; set; }
        public string Accounting_SubNumber { get; set; }
        public string Accounting_Number { get; set; }
        public bool IsDeleted { get; set; }
        public long GenderId { get; set; }
        public Nullable<long> GrpSupplierId { get; set; }
        public Nullable<long> Supplier_Offline_Id { get; set; }
        public string Supplier_Offline_Code { get; set; }
        public string Supplier_Offline_SyncCode { get; set; }
        public Nullable<long> MixSupplierId { get; set; }
        public string BirthDay_ConvertVarChar { get; set; }
        public string SupplierName_English { get; set; }
        public Nullable<long> RegionalId { get; set; }
        public Nullable<long> Supplier_BodyLookingId { get; set; }
        public string TimeStampText { get; set; }
        public string GrpSupplierCode { get; set; }
        public string FacebookURL { get; set; }
        public long Id { get; set; }
        public Nullable<long> GrpSupplier4ReportId { get; set; }
        public string SupplierNameOfficial { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Material> Materials { get; set; }
    }
}
