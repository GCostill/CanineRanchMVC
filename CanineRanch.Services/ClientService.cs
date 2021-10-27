using CanineRanch.Data;
using CanineRanch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanineRanch.Services
{
    public class ClientService
    {
        private readonly Guid _userId;

        public ClientService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateClient(ClientCreate model)
        {
            var entity = new Client()
            {
                ID = _userId,
                FirstName = model.FirstName,
                LastName = model.LastName,
                StreetAddress = model.StreetAddress,
                City = model.City,
                State = model.State,
                ZipCode = model.ZipCode,
                PhoneNumber = model.PhoneNumber,
                Email = model.Email
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Clients.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ClientListItem> GetClients()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Clients
                        .Where(e => e.ID == _userId)
                        .Select(
                            e =>
                                new ClientListItem
                                {
                                    ClientID = e.ClientID,
                                    FirstName = e.FirstName,
                                    LastName = e.LastName,
                                    PhoneNumber = e.PhoneNumber,
                                    Email = e.Email
                                }
                        );
                return query.ToArray();                               
            }
        }

        public ClientDetail GetClientByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Clients
                        .Single(e => e.ClientID == id && e.ID == _userId);
                return
                    new ClientDetail
                    {
                        ClientID = entity.ClientID,
                        FirstName = entity.FirstName,
                        LastName = entity.LastName,
                        StreetAddress = entity.StreetAddress,
                        City = entity.City,
                        State = entity.State,
                        ZipCode = entity.ZipCode,
                        PhoneNumber = entity.PhoneNumber,
                        Email = entity.Email
                    };
            }
        }

        public bool UpdateClient(ClientEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Clients
                        .Single(e => e.ClientID == model.ClientID && e.ID == _userId);
                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;
                entity.StreetAddress = model.StreetAddress;
                entity.City = model.City;
                entity.State = model.State;
                entity.ZipCode = model.ZipCode;
                entity.PhoneNumber = model.PhoneNumber;
                entity.Email = model.Email;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteClient(int clientID)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Clients
                        .Single(e => e.ClientID == clientID && e.ID == _userId);

                ctx.Clients.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
