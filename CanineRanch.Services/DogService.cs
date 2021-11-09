using CanineRanch.Data;
using CanineRanch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CanineRanch.Services
{
    public class DogService
    {
        private readonly Guid _userId;

        public DogService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateDog(DogCreate model)
        {
            var entity = new Dog()
            {
                ID = _userId,
                DogName = model.DogName,
                Breed = model.Breed,
                Age = model.Age,
                IsFixed = model.IsFixed
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Dogs.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<DogListItem> GetDogs()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Dogs
                        .Where(e => e.ID == _userId)
                        .Select(
                            e =>
                                new DogListItem
                                {
                                    DogID = e.DogID,
                                    DogName = e.DogName,
                                    Breed = e.Breed,
                                    IsFixed = e.IsFixed
                                }
                        );
                return query.ToArray();
            }
        }
        public DogDetail GetDogByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Dogs
                        .Single(e => e.DogID == id && e.ID == _userId);
                return
                    new DogDetail
                    {
                        DogID = entity.DogID,
                        DogName = entity.DogName,
                        Breed = entity.Breed,
                        Age = entity.Age,
                        IsFixed = entity.IsFixed
                    };
            }
        }

        public IEnumerable<SelectListItem> GetDogsForDropdown()
        {
            using(var ctx = new ApplicationDbContext())
            {
                var dogQuery =
                    ctx
                    .Dogs
                    .Select(e => new SelectListItem
                    {
                        Text = e.DogName,
                        Value = e.DogID.ToString()
                    });
                return dogQuery.ToArray();
            }
        }

        public bool UpdateDog(DogEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Dogs
                        .Single(e => e.DogID == model.DogID && e.ID == _userId);
                entity.DogName = model.DogName;
                entity.Breed = model.Breed;
                entity.Age = model.Age;
                entity.IsFixed = model.IsFixed;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteDog(int dogID)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Dogs
                        .Single(e => e.DogID == dogID && e.ID == _userId);

                ctx.Dogs.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
