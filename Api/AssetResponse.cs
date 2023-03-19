namespace SnipeITdotNET.Api
{
    public class AssetResponse
    {
        public int Total { get; set; }
        public AssetRow[]? Rows { get; set; }
    }

    public class AssetRow
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string asset_tag { get; set; }
        public string serial { get; set; }
        public Model model { get; set; }
        public bool byod { get; set; }
        public string model_number { get; set; }
        public int eol { get; set; }
        public object asset_eol_date { get; set; }
        public Status_Label status_label { get; set; }
        public Category category { get; set; }
        public object manufacturer { get; set; }
        public Supplier supplier { get; set; }
        public string notes { get; set; }
        public string order_number { get; set; }
        public object company { get; set; }
        public Location location { get; set; }
        public Rtd_Location rtd_location { get; set; }
        public string image { get; set; }
        public string qr { get; set; }
        public object alt_barcode { get; set; }
        public Assigned_To assigned_to { get; set; }
        public object warranty_months { get; set; }
        public object warranty_expires { get; set; }
        public Created_At created_at { get; set; }
        public Updated_At updated_at { get; set; }
        public object last_audit_date { get; set; }
        public object next_audit_date { get; set; }
        public object deleted_at { get; set; }
        public Purchase_Date purchase_date { get; set; }
        public string age { get; set; }
        public object last_checkout { get; set; }
        public object expected_checkin { get; set; }
        public string purchase_cost { get; set; }
        public int checkin_counter { get; set; }
        public int checkout_counter { get; set; }
        public int requests_counter { get; set; }
        public bool user_can_checkout { get; set; }
        public Custom_Fields custom_fields { get; set; }
        public Available_Actions available_actions { get; set; }
    }

    public class Model
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class Status_Label
    {
        public int id { get; set; }
        public string name { get; set; }
        public string status_type { get; set; }
        public string status_meta { get; set; }
    }

    public class Category
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class Supplier
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class Location
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class Rtd_Location
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class Assigned_To
    {
        public int id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
    }

    public class Created_At
    {
        public string datetime { get; set; }
        public string formatted { get; set; }
    }

    public class Updated_At
    {
        public string datetime { get; set; }
        public string formatted { get; set; }
    }

    public class Purchase_Date
    {
        public string date { get; set; }
        public string formatted { get; set; }
    }

    public class Custom_Fields
    {
        public RAM RAM { get; set; }
        public CPU CPU { get; set; }
        public MACAddress MACAddress { get; set; }
    }

    public class RAM
    {
        public string field { get; set; }
        public string value { get; set; }
        public string field_format { get; set; }
        public string element { get; set; }
    }

    public class CPU
    {
        public string field { get; set; }
        public string value { get; set; }
        public string field_format { get; set; }
        public string element { get; set; }
    }

    public class MACAddress
    {
        public string field { get; set; }
        public string value { get; set; }
        public string field_format { get; set; }
        public string element { get; set; }
    }

    public class Available_Actions
    {
        public bool checkout { get; set; }
        public bool checkin { get; set; }
        public bool clone { get; set; }
        public bool restore { get; set; }
        public bool update { get; set; }
        public bool delete { get; set; }
    }
}

