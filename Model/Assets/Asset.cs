using System.Text.Json.Serialization;

namespace SnipeITdotNET.Model.Assets
{
    public class Asset : ApiModel
    {
        // Use this instead of attributes
        public override Dictionary<string, string> BuildHeaders()
        {
            //base.BuildHeaders();

            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                // Required
                { "asset_tag", AssetTag },
                { "model_id", Model.Id.ToString() },
                { "status_id", StatusLabel.Id.ToString() }

                // Optional
                // todo, null checking etc
            };

            return headers;
        }

        [JsonPropertyName("asset_tag")]
        public string AssetTag { get; set; }

        [JsonPropertyName("serial")]
        public string Serial { get; set; }

        [JsonPropertyName("model")]
        public Model Model { get; set; }

        [JsonPropertyName("model_id")]
        private Model _model { set { Model = value; } }

        [JsonPropertyName("byod")]
        public bool Byod { get; set; }

        [JsonPropertyName("model_number")]
        public string ModelNumber { get; set; }

        [JsonPropertyName("eol")]
        public int Eol { get; set; }

        [JsonPropertyName("asset_eol_date")]
        public object AssetEolDate { get; set; }

        [JsonPropertyName("status_label")]
        public StatusLabel StatusLabel { get; set; }

        [JsonPropertyName("category")]
        public Category Category { get; set; }

        [JsonPropertyName("manufacturer")]
        public object Manufacturer { get; set; }

        [JsonPropertyName("supplier")]
        public Supplier Supplier { get; set; }

        [JsonPropertyName("notes")]
        public string Notes { get; set; }

        [JsonPropertyName("order_number")]
        public string OrderNumber { get; set; }

        [JsonPropertyName("company")]
        public object Company { get; set; }

        [JsonPropertyName("location")]
        public Location Location { get; set; }

        [JsonPropertyName("rtd_location")]
        public RtdLocation RtdLocation { get; set; }

        [JsonPropertyName("image")]
        public string Image { get; set; }

        [JsonPropertyName("qr")]
        public string Qr { get; set; }

        [JsonPropertyName("alt_barcode")]
        public object AltBarcode { get; set; }

        [JsonPropertyName("assigned_to")]
        public object AssignedTo { get; set; }

        [JsonPropertyName("warranty_months")]
        public object WarrantyMonths { get; set; }

        [JsonPropertyName("warranty_expires")]
        public object WarrantyExpires { get; set; }

        [JsonPropertyName("last_audit_date")]
        public object LastAuditDate { get; set; }

        [JsonPropertyName("next_audit_date")]
        public object NextAuditDate { get; set; }

        [JsonPropertyName("deleted_at")]
        public object DeletedAt { get; set; }

        [JsonPropertyName("purchase_date")]
        public PurchaseDate PurchaseDate { get; set; }

        [JsonPropertyName("age")]
        public string Age { get; set; }

        [JsonPropertyName("last_checkout")]
        public object LastCheckout { get; set; }

        [JsonPropertyName("expected_checkin")]
        public object ExpectedCheckin { get; set; }

        [JsonPropertyName("purchase_cost")]
        public string PurchaseCost { get; set; }

        [JsonPropertyName("checkin_counter")]
        public int CheckinCounter { get; set; }

        [JsonPropertyName("checkout_counter")]
        public int CheckoutCounter { get; set; }

        [JsonPropertyName("requests_counter")]
        public int RequestsCounter { get; set; }

        [JsonPropertyName("user_can_checkout")]
        public bool UserCanCheckout { get; set; }

        [JsonPropertyName("custom_fields")]
        public CustomFields CustomFields { get; set; }

        [JsonPropertyName("available_actions")]
        public AvailableActions AvailableActions { get; set; }
    }
    public class AvailableActions
    {
        [JsonPropertyName("checkout")]
        public bool Checkout { get; set; }

        [JsonPropertyName("checkin")]
        public bool Checkin { get; set; }

        [JsonPropertyName("clone")]
        public bool Clone { get; set; }

        [JsonPropertyName("restore")]
        public bool Restore { get; set; }

        [JsonPropertyName("update")]
        public bool Update { get; set; }

        [JsonPropertyName("delete")]
        public bool Delete { get; set; }
    }

    public class Category
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }

    public class CreatedAt
    {
        [JsonPropertyName("datetime")]
        public string Datetime { get; set; }

        [JsonPropertyName("formatted")]
        public string Formatted { get; set; }
    }

    public class CustomFields // remove this
    {
        [JsonPropertyName("IMEI")]
        public IMEI IMEI { get; set; }

        [JsonPropertyName("Phone Number")]
        public PhoneNumber PhoneNumber { get; set; }
    }

    public class IMEI
    {
        [JsonPropertyName("field")]
        public string Field { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }

        [JsonPropertyName("field_format")]
        public string FieldFormat { get; set; }

        [JsonPropertyName("element")]
        public string Element { get; set; }
    }

    public class Location
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }

    public class Model
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }

    public class PhoneNumber
    {
        [JsonPropertyName("field")]
        public string Field { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }

        [JsonPropertyName("field_format")]
        public string FieldFormat { get; set; }

        [JsonPropertyName("element")]
        public string Element { get; set; }
    }

    public class PurchaseDate
    {
        [JsonPropertyName("date")]
        public string Date { get; set; }

        [JsonPropertyName("formatted")]
        public string Formatted { get; set; }
    }

    public class RtdLocation
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }

    public class StatusLabel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("status_type")]
        public string StatusType { get; set; }

        [JsonPropertyName("status_meta")]
        public string StatusMeta { get; set; }
    }

    public class Supplier
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }

    public class UpdatedAt
    {
        [JsonPropertyName("datetime")]
        public string Datetime { get; set; }

        [JsonPropertyName("formatted")]
        public string Formatted { get; set; }
    }


}
