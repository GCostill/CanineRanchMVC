using CanineRanch.Data;
using CanineRanch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanineRanch.Services
{
    public class GroomingRequestService
    {
        private readonly Guid _userId;

        public GroomingRequestService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateGroomingRequest(GroomingRequestCreate model)
        {
            var entity = new GroomingRequest()
            {
                GroomFrequency = model.GroomFrequency,
                FirstTimeGroom = model.FirstTimeGroom,
                RequestTimeStamp = DateTime.Now,
               // Dog.DogName = model.DogName
            };
            //GET DOG BY NAME INPUTTED
            using(var ctx = new ApplicationDbContext())
            {
                
                //var dogToAdd = 
                //    ctx
                //        .Dogs
                //        .Where(e => e.DogName == model.DogName)
                //        .Select(e => new Dog
                //         {
                //             DogID = entity.Dog.DogID,
                //             DogName = entity.Dog.DogName,
                //             Age = entity.Dog.Age,
                //             Breed = entity.Dog.Breed,
                //             IsFixed = entity.Dog.IsFixed,
                //         });

                ctx.GroomingRequests.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<GroomingRequestListItem> GetGroomingRequests()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .GroomingRequests
                        .Where(e => e.ID == _userId)
                        .Select(
                            e =>
                                new GroomingRequestListItem
                                {
                                    RequestID = e.RequestID,
                                    DogName = e.Dog.DogName,
                                    FirstTimeGroom = e.FirstTimeGroom,
                                    RequestTimeStamp = e.RequestTimeStamp
                                }
                        );
                return query.ToArray();
            }
        }

        public GroomingRequestDetail GetGroomingRequestByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .GroomingRequests
                        .Single(e => e.RequestID == id && e.ID == _userId);
                return
                    new GroomingRequestDetail
                    {
                        RequestID = entity.RequestID,
                        DogID = entity.DogID,
                        GroomFrequency = entity.GroomFrequency,
                        FirstTimeGroom = entity.FirstTimeGroom,
                        RequestTimeStamp = entity.RequestTimeStamp
                    };
            }
        }

        public bool DeleteGroomingRequest(int requestID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .GroomingRequests
                        .Single(e => e.RequestID == requestID && e.ID == _userId);

                ctx.GroomingRequests.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
