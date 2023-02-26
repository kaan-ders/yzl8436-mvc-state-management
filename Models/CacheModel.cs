namespace StateManagement.Models
{
    public class CacheModel
    {
        public int Id { get; set; }
        public string KategoriAdi { get; set; }

        public static List<CacheModel> Listele()
        {
            return new List<CacheModel>
            {
                new CacheModel
                {
                    Id = 1,
                    KategoriAdi = "Fareler"
                },
                new CacheModel
                {
                    Id = 2,
                    KategoriAdi = "Monitörler"
                },
                new CacheModel
                {
                    Id = 3,
                    KategoriAdi = "Bilgisayarlar"
                }
            };
        }
    }
}
