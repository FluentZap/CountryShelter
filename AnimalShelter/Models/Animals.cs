using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace AnimalShelter.Model
{



  public class Animal
  {
    public string Name {get; set;}
    public string Breed {get; set;}
    public string Id {get; set;}

    public Animal (string id, string name, string breed)
    {
      Id = id;
      Name = name;
      Breed = breed;
    }

    public override bool Equals(System.Object otherAnimal)
    {
      if (!(otherAnimal is Animal))
      {
        return false;
      }
      Animal newAnimal = (Animal) otherAnimal;
      bool namesAreEqual = this.Name.Equals(newAnimal.Name);
      bool breedsAreEqual = this.Breed.Equals(newAnimal.Breed);

      return namesAreEqual && breedsAreEqual;
    }

    public static List<Animal> GetAll()
    {
      List<Animal> animals = new List<Animal> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM country;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        string Code = rdr.GetString(0);
        string Name = rdr.GetString(1);
        string GovernmentForm = rdr.GetString(11);
        animals.Add(new Animal(Code, Name, GovernmentForm));
      }
      DB.CloseDatabase(conn);
      return animals;
    }

    public static Animal GetAnimal(string code)
    {
      Animal returnAnimal = new Animal("Id", "name", "breed");
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM country WHERE Code = @code;";
      MySqlParameter thisCode = new MySqlParameter();
      thisCode.ParameterName = "@code";
      thisCode.Value = code;
      cmd.Parameters.Add(thisCode);
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        string Code = rdr.GetString(0);
        string Name = rdr.GetString(1);
        string GovernmentForm = rdr.GetString(11);
        returnAnimal = new Animal(Code, Name, GovernmentForm);
      }

      DB.CloseDatabase(conn);
      return returnAnimal;
    }

    public static void RemoveAnimal(string code)
    {
      RemoveItem(code, "city", "countrycode");
      RemoveItem(code, "countrylanguage", "countrycode");
      RemoveItem(code, "country", "code");
    }

    private static void RemoveItem(string code, string table, string id)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM " + table + " WHERE " + id +" = @code;";
      cmd.Parameters.AddWithValue("@code", code);
      cmd.ExecuteNonQuery();

      DB.CloseDatabase(conn);
    }



  }
}
