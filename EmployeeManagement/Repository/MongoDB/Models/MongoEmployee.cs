using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Repository.MongoDB.Models
{
   public class MongoEmployee
   {
      [BsonId]
      [BsonRepresentation(BsonType.ObjectId)]
      public string Id { get; set; }

      [Required]
      public string FirstName { get; set; }

      [Required]
      public string LastName { get; set; }

      [Required]
      public string Gender { get; set; }

      [Required]
      public string Email { get; set; }

      [BsonDateTimeOptions(DateOnly = true)]
      [Required]
      public DateTime DOB { get; set; }

      [Required]
      public string Phone { get; set; }

      public string Bio { get; set; }

      [BsonRepresentation(BsonType.ObjectId)]
      public string EmployeeTypeId { get; set; }

      [BsonIgnore]
      public MongoEmployeeType MongoEmployeeType;
   }
}

