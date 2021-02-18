﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using VinylAppApi.Shared.Models.AuthorizationModels;
using VinylAppApi.Shared.Models.DbModels;

namespace VinylAppApi.DataAccess.DbManager
{
    public class DbClient : IDbClient
    {
        private readonly IMongoCollection<OwnedAlbumModel> _ownedAlbums;
        private readonly IMongoCollection<UserModel> _databaseUser;
        private ILogger<DbClient> _logger;

        public DbClient(ILogger<DbClient> logger, IConfiguration configuration)
        {
            var config = configuration;
            _logger = logger;

            var dbClient = new MongoClient(config.GetConnectionString("MongoDb"));
            var db = dbClient.GetDatabase("vinyl-db");
            _ownedAlbums = db.GetCollection<OwnedAlbumModel>("albums");
            _databaseUser = db.GetCollection<UserModel>("users");
        }

        public IMongoCollection<OwnedAlbumModel> AlbumCollection()
        {
            return _ownedAlbums;
        }

        public IMongoCollection<UserModel> UsersCollection()
        {
            return _databaseUser;
        }
    }
}