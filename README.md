# helper.cs Library

### Description:
C# Library contain several methods for easy & friendly working on your c# .net projects, instead repeating all sql server mechanisme and functions add to usaly other functions, you can make that short coded with this class

### Documentation:

#### create new helper class
```
helper hlpr = new helper();
```

#### create an SQL Connection with your data base
for this purpose you have to configurate the server and the database names in the original class here
cs```
    public void Connect()
    {
        string ServerName = "[Your SQL Server Name Here]";
        string DbName = "[Your SQL Server DataBase Name Here]";
        if (con.State == ConnectionState.Closed || con.State == ConnectionState.Broken)
        {
            con.ConnectionString = string.Format(@"data source={0}; initial catalog={1}; integrated security=true", ServerName, DbName);
            con.Open();
        }
    }
```
for implement the method in your application form type
```
hlpr.Connect()
```

#### create an SQL Deconnection
```
hlpr.Deconnect();
```

#### Add values into DataBase Table
By Default there are 3 columns in the target table, you can modify the original class code for add or remove columns
```
hlpr.InsertToDb("[You_Table_Name]", "columnOneValue", "columnTwoValue", "columnThreeValue");
```

#### Remove Row from your DataBase table
```
hlpr.number("[your_Primary_Key]", "[You_Table_Name]", PK_value);
```

#### Modify a Row
By Default there are 3 columns in the target table (named as well by default), you have to modify the ModifyRowDb methode code for add or remove columns
```
hlpr.ModifyRowDb("[You_Table_Name]", "columnOneValue", "columnTwoValue", "columnThreeValue");
```

#### Search at a table
get the dataTable that contain the result of the Search
```
DataTable Result = hlpr.SearchDb("[You_Table_Name]", "[your_Primary_Key]", idBox.Text);
```

#### Download for linux (move it on the project folder):
```
wget https://raw.githubusercontent.com/hamza07-w/helper.cs/main/helper%20class/helper.cs
```


#### Note:
There are many other functions, Refrech - Clear - Exit. and upcaming ones for sure ...
