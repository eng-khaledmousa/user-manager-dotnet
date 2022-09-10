using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using UserManager.Entities;

namespace UserManager.Repositories{
    class UserRepository : IUserRepository
    {
        private const string databaseName = "usermanager";
        private const string collectionName = "users";
        private readonly IMongoCollection<User> usersCollection;
        private readonly FilterDefinitionBuilder<User> filterBuilder = Builders<User>.Filter;
        public UserRepository(IMongoClient mongoClient)
        {
            IMongoDatabase db = mongoClient.GetDatabase(databaseName);
            usersCollection = db.GetCollection<User> (collectionName);
        }
        public async Task CreateUserAsync(User user)
        {
            await usersCollection.InsertOneAsync(user);
        }

        public async Task<User> GetUserAsync(Guid id)
        {
            var filter = filterBuilder.Eq(user => user.Id, id);
            return await usersCollection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<bool> CheckUserExistAsync(string username)
        {
            var filter = filterBuilder.Eq(user => user.UserName, username);
            var user = await usersCollection.Find(filter).FirstOrDefaultAsync();
            if(user != null){
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await  usersCollection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task UpdateUserAsync(User user)
        {
            Console.WriteLine(user);
            var filter = filterBuilder.Eq(existingUser => existingUser.Id, user.Id);
            await usersCollection.ReplaceOneAsync(filter, user);
        }
        public async Task DeleteUserAsync(User user)
        {
            var filter = filterBuilder.Eq(existingUser => existingUser.Id, user.Id);
            await usersCollection.DeleteOneAsync(filter);
        }
    }
}