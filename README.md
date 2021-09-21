# Important
Tovuti - How to run

1. Create a postgresql database with these details
- username: tovuti_User
- database name: tovuti_Db
- password: tovuti_Password
- port: 5432
- host: localhost 
1. Run migrations against the tovuti.EntityFrameworkCore dir 

$ dotnet ef database update

2. Run the server against tovuti.Web.Host dir
$ dotnet run

3. Run the angular app from tovuti\angular dir
$ npm install
$ npm run
# License

[MIT](LICENSE).
