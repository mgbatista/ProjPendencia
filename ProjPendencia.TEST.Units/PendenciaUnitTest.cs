using Microsoft.EntityFrameworkCore;
using ProjPendeincia.API.Controllers;
using ProjPendeincia.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ProjPendencia.TEST.Units
{
    public class PendenciaUnitTest
    {
        private DbContextOptions<PendenciaContext> options;

        private void InitializeDataBase()
        {
            // Create a Temporary Database
            options = new DbContextOptionsBuilder<PendenciaContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            // Insert data into the database using one instance of the context
            using (var context = new PendenciaContext(options))
            {
                context.Pendencia.Add(new Pendencia { Id = 1, Descricao = "Pendencia 1", Data = "06/04/2021"});
                context.Pendencia.Add(new Pendencia { Id = 2, Descricao = "Pendencia 2", Data = "07/04/2021"});
                context.Pendencia.Add(new Pendencia { Id = 3, Descricao = "Pendencia 3", Data = "08/04/2021"});
                context.SaveChanges();
            }
        }

        [Fact]
        public void GetAll()
        {
            InitializeDataBase();

            // Use a clean instance of the context to run the test
            using (var context = new PendenciaContext(options))
            {
                PendenciaController pendenciaController = new PendenciaController(context);
                IEnumerable<Pendencia> pendencias = pendenciaController.GetPendencia().Result.Value;
    
                Assert.Equal(3, pendencias.Count());
            }
        }

        [Fact]
        public void GetbyId()
        {
            InitializeDataBase();

            // Use a clean instance of the context to run the test
            using (var context = new PendenciaContext(options))
            {
                int pendenciaId = 2;
                PendenciaController pendenciaController = new PendenciaController(context);
                Pendencia pendencia = pendenciaController.GetPendencia(pendenciaId).Result.Value;
                Assert.Equal(2, pendencia.Id);
            }
        }

        [Fact]
        public void Create()
        {
            InitializeDataBase();

            Pendencia pendencia = new Pendencia()
            {
                Id = 4,
                Descricao = "Pendencia 4",
                Data = "04/04/2021"
            };

            // Use a clean instance of the context to run the test
            using (var context = new PendenciaContext(options))
            {
                PendenciaController pendenciaController = new PendenciaController(context);
                Pendencia pend = pendenciaController.PostPendencia(pendencia).Result.Value;
                Assert.Equal(4, pend.Id);
            }
        }

        [Fact]
        public void Update()
        {
            InitializeDataBase();

            Pendencia pendencia = new Pendencia()
            {
                Id = 3,
                Descricao = "Pendencia 4",
                Data = "04/04/2021"
            };

            // Use a clean instance of the context to run the test
            using (var context = new PendenciaContext(options))
            {
                PendenciaController pendenciaController = new PendenciaController(context);
                Pendencia pend = pendenciaController.PutPendencia(3, pendencia).Result.Value;
                Assert.Equal("Pendencia 4", pend.Descricao);
            }
        }

        [Fact]
        public void Delete()
        {
            InitializeDataBase();

            // Use a clean instance of the context to run the test
            using (var context = new PendenciaContext(options))
            {
                PendenciaController pendenciaController = new PendenciaController(context);
                Pendencia pendencia = pendenciaController.DeletePendencia(2).Result.Value;
                Assert.Null(pendencia);
            }
        }
    }
}