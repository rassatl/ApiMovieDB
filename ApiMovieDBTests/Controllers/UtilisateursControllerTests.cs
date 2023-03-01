using Microsoft.VisualStudio.TestTools.UnitTesting;
using ApiMovieDB.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiMovieDB.Models.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.AspNetCore.Http;
using ApiMovieDB.Models.Repository;
using ApiMovieDB.Models.DataManager;
using Moq;

namespace ApiMovieDB.Controllers.Tests
{
    [TestClass()]
    public class UtilisateursControllerTests
    {
        private readonly FilmRatingDBContexts _context;
        private readonly UtilisateursController _controller;
        private IDataRepository<Utilisateur> _dataRepository;
        public UtilisateursControllerTests()
        {
            var builder = new DbContextOptionsBuilder<FilmRatingDBContexts>().UseNpgsql("Server=localhost;port=5432;Database=FilmDB; uid=bubu; password=password;"); // Chaine de connexion à mettre dans les ( )
            _context = new FilmRatingDBContexts(builder.Options);
            _dataRepository = new UtilisateurManager(_context);
            _controller = new UtilisateursController(_dataRepository);
            
        }


        //[TestMethod()]
        //public void UtilisateursControllerTest()
        //{
            
        //}

        [TestMethod()]
        public async Task GetUtilisateursTestAsync()
        {
            ActionResult<IEnumerable<Utilisateur>> users =  await _controller.GetUtilisateurs();
            CollectionAssert.AreEqual(_context.Utilisateurs.ToList(), users.Value.ToList(), "La liste renvoyée n'est pas la bonne.");
        }

        [TestMethod()]
        public async Task GetUtilisateurByIdTest()
        {
            ActionResult<Utilisateur> user = await _controller.GetUtilisateurById(1);
            Assert.AreEqual(_context.Utilisateurs.Where(c => c.UtilisateurId == 1).FirstOrDefault(), user.Value,"Utilisateur différent");
        }
        [TestMethod()]
        public async Task GetUtilisateurByIdTestFalse()
        {
            ActionResult<Utilisateur> user = await _controller.GetUtilisateurById(1);
            Assert.AreNotEqual(_context.Utilisateurs.Where(c => c.UtilisateurId == 2).FirstOrDefault(), user.Value, "Utilisateur différent");
        }

        [TestMethod]
        public void GetUtilisateurById_ExistingIdPassed_ReturnsRightItem_AvecMoq()
        {
            // Arrange
            Utilisateur user = new Utilisateur
            {
                UtilisateurId = 1,
                Nom = "Calida",
                Prenom = "Lilley",
                Mobile = "0653930778",
                Mail = "clilleymd@last.fm",
                Pwd = "Toto12345678!",
                Rue = "Impasse des bergeronnettes",
                CodePostal = "74200",
                Ville = "Allinges",
                Pays = "France",
                Latitude = 46.344795F,
                Longitude = 6.4885845F
            };
            var mockRepository = new Mock<IDataRepository<Utilisateur>>();
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(user);
            var userController = new UtilisateursController(mockRepository.Object);
            // Act
            var actionResult = userController.GetUtilisateurById(1).Result;
            // Assert
            Assert.IsNotNull(actionResult);
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(user, actionResult.Value as Utilisateur);
        }

        [TestMethod]
        public void GetUtilisateurById_UnknownIdPassed_ReturnsNotFoundResult_AvecMoq()
        {
            var mockRepository = new Mock<IDataRepository<Utilisateur>>();
            var userController = new UtilisateursController(mockRepository.Object);
            // Act
            var actionResult = userController.GetUtilisateurById(0).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult.Result, typeof(NotFoundResult));
        }


        [TestMethod()]
        public async Task GetUtilisateurByEmailTest()
        {
            ActionResult<Utilisateur> user = await _controller.GetUtilisateurByEmail("kbomea@networksolutions.com");
            Assert.AreEqual(_context.Utilisateurs.Where(c => c.Mail == "kbomea@networksolutions.com").FirstOrDefault(), user.Value, "Utilisateur différent");
        }
        [TestMethod()]
        public async Task GetUtilisateurByEmailTestFale()
        {
            ActionResult<Utilisateur> user = await _controller.GetUtilisateurByEmail("kbomea@networksolutions.com");
            Assert.AreNotEqual(_context.Utilisateurs.Where(c => c.Mail == "mathis.bozon03@gmail.com").FirstOrDefault(), user.Value, "Utilisateur différent");
        }


        public void GetUtilisateurByMail_ExistingIdPassed_ReturnsRightItem_AvecMoq()
        {
            // Arrange
            Utilisateur user = new Utilisateur
            {
                UtilisateurId = 1,
                Nom = "Calida",
                Prenom = "Lilley",
                Mobile = "0653930778",
                Mail = "clilleymd@last.fm",
                Pwd = "Toto12345678!",
                Rue = "Impasse des bergeronnettes",
                CodePostal = "74200",
                Ville = "Allinges",
                Pays = "France",
                Latitude = 46.344795F,
                Longitude = 6.4885845F
            };
            var mockRepository = new Mock<IDataRepository<Utilisateur>>();
            mockRepository.Setup(x => x.GetByStringAsync("clilleymd@last.fm").Result).Returns(user);
            var userController = new UtilisateursController(mockRepository.Object);
            // Act
            var actionResult = userController.GetUtilisateurByEmail("clilleymd@last.fm").Result;
            // Assert
            Assert.IsNotNull(actionResult);
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(user, actionResult.Value as Utilisateur);
        }

        [TestMethod]
        public void GetUtilisateurByMail_UnknownIdPassed_ReturnsNotFoundResult_AvecMoq()
        {
            var mockRepository = new Mock<IDataRepository<Utilisateur>>();
            var userController = new UtilisateursController(mockRepository.Object);
            // Act
            var actionResult = userController.GetUtilisateurByEmail("-1").Result;
            // Assert
            Assert.IsInstanceOfType(actionResult.Result, typeof(NotFoundResult));
        }

        [TestMethod()]
        public async Task PutUtilisateurTest()
        {
            Utilisateur user = await _context.Utilisateurs.FindAsync(1);
            user.Nom += "a";
            await _controller.PutUtilisateur(user.UtilisateurId, user);
            Utilisateur modifie = await _context.Utilisateurs.FindAsync(1);
            Assert.AreEqual(user, modifie, "pas les memes");
        }

        [TestMethod]
        public void PutUtilisateurTest_AvecMoq()
        {
            // Le mail doit être unique donc 2 possibilités :
            // 1. on s'arrange pour que le mail soit unique en concaténant un random ou un timestamp
            // 2. On supprime le user après l'avoir créé. Dans ce cas, nous avons besoin d'appeler la méthode DELETE de l’API ou remove du DbSet.
            Utilisateur user = new Utilisateur()
            {
                Nom = "MACHIN",
                Prenom = "Luc",
                Mobile = "0606070809",
                Mail = "machin" + "@gmail.com",
                Pwd = "Toto1234!",
                Rue = "Chemin de Bellevue",
                CodePostal = "74940",
                Ville = "Annecy-le-Vieux",
                Pays = "France",
                Latitude = null,
                Longitude = null
            };

            // Act
            var mockRepository = new Mock<IDataRepository<Utilisateur>>();
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(user);
            var userController = new UtilisateursController(mockRepository.Object);


            user.Nom= "a";
            userController.PutUtilisateur(user.UtilisateurId, user);

            var actionResult = userController.GetUtilisateurById(1).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult<Utilisateur>), "Pas un ActionResult<Utilisateur>");
            var result = actionResult.Value;
            Console.WriteLine(result.GetType());
            Assert.IsInstanceOfType(result, typeof(Utilisateur), "Pas un Utilisateur");
            user.UtilisateurId = ((Utilisateur)result).UtilisateurId;
            Assert.AreEqual(user, (Utilisateur)result, "Utilisateurs pas identiques");
        }


        [TestMethod()]
        public async Task PostUtilisateurTest()
        {
            // Arrange
            var mockRepository = new Mock<IDataRepository<Utilisateur>>();
            var userController = new UtilisateursController(mockRepository.Object);
            // Le mail doit être unique donc 2 possibilités :
            // 1. on s'arrange pour que le mail soit unique en concaténant un random ou un timestamp
            // 2. On supprime le user après l'avoir créé. Dans ce cas, nous avons besoin d'appeler la méthode DELETE de l’API ou remove du DbSet.
            Utilisateur user = new Utilisateur()
            {
                Nom = "MACHIN",
                Prenom = "Luc",
                Mobile = "0606070809",
                Mail = "machin" + "@gmail.com",
                Pwd = "Toto1234!",
                Rue = "Chemin de Bellevue",
                CodePostal = "74940",
                Ville = "Annecy-le-Vieux",
                Pays = "France",
                Latitude = null,
                Longitude = null
            };
            // Act
            var actionResult = userController.PostUtilisateur(user).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult<Utilisateur>), "Pas un ActionResult<Utilisateur>");
            Assert.IsInstanceOfType(actionResult.Result, typeof(CreatedAtActionResult), "Pas un CreatedAtActionResult");
            var result = actionResult.Result as CreatedAtActionResult;
            Assert.IsInstanceOfType(result.Value, typeof(Utilisateur), "Pas un Utilisateur");
            user.UtilisateurId = ((Utilisateur)result.Value).UtilisateurId;
            Assert.AreEqual(user, (Utilisateur)result.Value, "Utilisateurs pas identiques");
        }

        [TestMethod()]
        public async Task DeleteUtilisateurTest()
        {
            Random rnd = new Random();
            int chiffre = rnd.Next(1, 1000000000);
            Utilisateur userAtester = new Utilisateur()
            {
                Nom = "MACHIN",
                Prenom = "Luc",
                Mobile = "0606070809",
                Mail = "machin" + chiffre + "@gmail.com",
                Pwd = "Toto1234!",
                Rue = "Chemin de Bellevue",
                CodePostal = "74940",
                Ville = "Annecy-le-Vieux",
                Pays = "France",
                Latitude = null,
                Longitude = null
            };
            EntityEntry<Utilisateur> res =  _context.Utilisateurs.Add(userAtester);
            _context.SaveChanges();
            IActionResult result = await _controller.DeleteUtilisateur(res.Entity.UtilisateurId);

            Utilisateur user = _context.Utilisateurs.Where(u => u.UtilisateurId == res.Entity.UtilisateurId).FirstOrDefault();

            Assert.IsNull(user, "Non");
            

        }

        //[TestMethod]
        //public void DeleteUtilisateurTest_AvecMoq()
        //{
        //    // Arrange
        //    var mockRepository = new Mock<IDataRepository<Utilisateur>>();
        //    var userController = new UtilisateursController(mockRepository.Object);
        //    // Act
        //    var actionResult = userController.DeleteUtilisateur(1).Result;
        //    // Assert
        //    Assert.IsInstanceOfType(actionResult, typeof(NoContentResult), "Pas un NoContentResult"); // Test du type de retour
        //}

        [TestMethod]
        public void DeleteUtilisateurTest_AvecMoq()
        {
            // Arrange
            Utilisateur user = new Utilisateur
            {
                UtilisateurId = 1,
                Nom = "Calida",
                Prenom = "Lilley",
                Mobile = "0653930778",
                Mail = "clilleymd@last.fm",
                Pwd = "Toto12345678!",
                Rue = "Impasse des bergeronnettes",
                CodePostal = "74200",
                Ville = "Allinges",
                Pays = "France",
                Latitude = 46.344795F,
                Longitude = 6.4885845F
            };
            var mockRepository = new Mock<IDataRepository<Utilisateur>>();
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(user);
            var userController = new UtilisateursController(mockRepository.Object);
            // Act
            var actionResult = userController.DeleteUtilisateur(1).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult), "Pas un NoContentResult"); // Test du type de retour
        }
    }
}