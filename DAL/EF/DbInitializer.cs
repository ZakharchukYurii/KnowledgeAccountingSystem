using DAL.Entities;
using System.Data.Entity;

namespace DAL.EF
{
    class DbInitializer : DropCreateDatabaseIfModelChanges<KnowledgeContext>
    {
        protected override void Seed(KnowledgeContext db)
        {
            Area frontEnd = new Area() { Name = "FrontEnd" };
            Area backEnd = new Area() { Name = "BackEnd" };
            Area language = new Area() { Name = "Language" };
            db.Areas.Add(frontEnd);
            db.Areas.Add(backEnd);
            db.Areas.Add(language);

            db.SaveChanges();
        }
    }
}
