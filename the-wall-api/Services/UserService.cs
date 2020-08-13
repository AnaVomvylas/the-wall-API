using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace the_wall_api.Services
{
    public class UserService
    {
        private readonly IMongoCollection<User> _users;
        private readonly DatabaseSettings _databaseSettings;

        public UserService(IOptions<DatabaseSettings> databaseSettings)
        {
            _databaseSettings = databaseSettings.Value;

            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _users = database.GetCollection<User>(_databaseSettings.UsersCollectionName);
        }

        public List<User> Get() =>
            _users.Find(user => true).ToList();

        public User Get(string id) =>
            _users.Find<User>(user => user.Id == id).FirstOrDefault();

        public User Create(User user)
        {
            _users.InsertOne(user);
            return user;
        }

        public void Update(string id, User userIn) => _users.ReplaceOne(user => user.Id == id, userIn);

        public void Remove(User userIn) =>
            _users.DeleteOne(user => user.Id == userIn.Id);

        public void Remove(string id) =>
            _users.DeleteOne(user => user.Id == id);

        public User Authenticate(AuthenticateRequest model)
        {
            User user = null;
            try
            {
                user = _users.Find<User>(user => user.Username == model.Username && user.Password == model.Password).FirstOrDefault();
            }
            catch (Exception ex)
            {
            }
            return user;
        }
    }
}