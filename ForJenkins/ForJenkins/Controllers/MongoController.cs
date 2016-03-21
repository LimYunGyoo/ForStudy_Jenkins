using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ForJenkins.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class MongoController : ApiController
    {

        public IHttpActionResult GetText()
        {
            int result = 0;

            // Mongo DB를 위한 Connection String
            string connString = "mongodb://10.21.202.59";

            // MongoClient 클라이언트 객체 생성
            MongoClient cli = new MongoClient(connString);

            // testdb 라는 데이타베이스 가져오기
            // 만약 해당 DB 없으면 Collection 생성시 새로 생성함
            IMongoDatabase logtest = cli.GetDatabase("logtest");

            // testdb 안에 Customers 라는 컬렉션(일종의 테이블)
            // 가져오기. 만약 없으면 새로 생성.
            var customers = logtest.GetCollection<Customer>("logtest");

            // INSERT - 컬렉션 객체의 Insert() 메서드 호출
            // Insert시 _id 라는 자동으로 ObjectID 생성 
            // 이 _id는 해당 다큐먼트는 나타는 키.
            for (int i = 0; i < 100000; i++)
            {
                result += i;
            }

            Customer cust1 = new Customer { Name = "log", Age = result, ThisTime = DateTime.Now };

            customers.InsertOne(cust1);

            return Ok("result ok : " + result);
        }
    }

    public class Customer
    {
        // 이 Id는 MongoDB Collection의 _id 컬럼과 매칭됨
        // (예외적인 Naming Convention)
        public ObjectId Id { get; set; }

        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime ThisTime { get; set; }


        public override string ToString()
        {
            return Name + " " + Age;
        }
    }
}
