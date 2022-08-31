namespace InsuriseDTO.Production.Warranties
{
    public class WarrantyFeatureDto
    {
        public WarrantyFeatureDto(int id, bool mandatory, int rank, int featureId, int warrantyId, string feature, string warranty)
        {
            Mandatory = mandatory;
            Rank = rank;
            WarrantyId = warrantyId; 
            FeatureId = featureId;
            Warranty = warranty;
            Feature = feature;
            IsChecked = true;
        }
        public int Id { get; set; }
        public bool Mandatory { get; set; }
        public int Rank { get; set; }
        public int FeatureId { get; set; }
        public string Feature { get; set; }
        public int WarrantyId { get; set; }
        public string Warranty { get; set; }
        public bool IsChecked { get; set; }

    }
}
