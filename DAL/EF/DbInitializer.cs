﻿using DAL.Entities;
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

            Knowledge english = new Knowledge() { Name = "English", Area = language };
            Knowledge ukrainian = new Knowledge() { Name = "Ukrainian", Area = language };
            Knowledge cSharp = new Knowledge() { Name = "C#", Area = backEnd };
            Knowledge php = new Knowledge() { Name = "PHP", Area = backEnd };
            Knowledge html = new Knowledge() { Name = "Html/Css", Area = frontEnd };
            Knowledge javaSkript = new Knowledge() { Name = "JavaSkript", Area = frontEnd };

            User admin = new User() { Name = "Admin" };
            User popov = new User() { Name = "Popov", FullName = "Oleg Popov", EMail = "olegpopov@gmail.com" };
            User karabas = new User() { Name = "Karabas", FullName = "Viktor Karabas" };

            KnowledgeRate rateUk = new KnowledgeRate() { User = popov, Knowledge = ukrainian, Rate = 5 };
            KnowledgeRate rateCs = new KnowledgeRate() { User = popov, Knowledge = cSharp, Rate = 3 };
            KnowledgeRate rateHtml = new KnowledgeRate() { User = popov, Knowledge = html, Rate = 2 };

            KnowledgeRate rateKarabasUk = new KnowledgeRate() { User = karabas, Knowledge = ukrainian, Rate = 5 };
            KnowledgeRate rateKarabasEn = new KnowledgeRate() { User = karabas, Knowledge = english, Rate = 4 };
            KnowledgeRate rateKarabasCs = new KnowledgeRate() { User = popov, Knowledge = cSharp, Rate = 2 };
            KnowledgeRate rateKarabasHtml = new KnowledgeRate() { User = karabas, Knowledge = html, Rate = 3 };
            KnowledgeRate rateKarabasJS = new KnowledgeRate() { User = karabas, Knowledge = javaSkript, Rate = 3 };

            db.Areas.Add(frontEnd);
            db.Areas.Add(backEnd);
            db.Areas.Add(language);

            db.Knowledges.Add(english);
            db.Knowledges.Add(ukrainian);
            db.Knowledges.Add(cSharp);
            db.Knowledges.Add(php);
            db.Knowledges.Add(html);
            db.Knowledges.Add(javaSkript);

            db.Users.Add(admin);
            db.Users.Add(popov);
            db.Users.Add(karabas);

            db.Rates.Add(rateUk);
            db.Rates.Add(rateCs);
            db.Rates.Add(rateHtml);

            db.Rates.Add(rateKarabasUk);
            db.Rates.Add(rateKarabasEn);
            db.Rates.Add(rateKarabasCs);
            db.Rates.Add(rateKarabasHtml);
            db.Rates.Add(rateKarabasJS);

            db.SaveChanges();
        }
    }
}
