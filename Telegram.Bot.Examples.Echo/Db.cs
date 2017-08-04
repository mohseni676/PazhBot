using System;
using System.Data;
using System.Data.SqlClient;

public class cmsDataClass
{
    public static SqlConnection GetConnection()
    {
        string connectionString
             = System.Configuration.ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
        SqlConnection connection = new SqlConnection(connectionString);
        return connection;
    }
}

public class dbo_tbCustomersDataClass
{
    public static dbo_tbCustomersClass Select_Record(dbo_tbCustomersClass clsdbo_tbCustomersPara)
    {
        dbo_tbCustomersClass clsdbo_tbCustomers = new dbo_tbCustomersClass();
        SqlConnection connection = cmsDataClass.GetConnection();
        string selectStatement
            = "SELECT "
            + "     [id] "
            + "    ,[TelegramId] "
            + "    ,[Fname] "
            + "    ,[Lname] "
            + "    ,[mobile] "
            + "    ,[address] "
            + "FROM "
            + "     [dbo].[tbCustomers] "
            + "WHERE "
            + "     [TelegramId] = @TelegramId "
            + "    [id] = @id "
            + "";
        SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
        selectCommand.CommandType = CommandType.Text;
        selectCommand.Parameters.AddWithValue("@TelegramId", clsdbo_tbCustomersPara.TelegramId);
        selectCommand.Parameters.AddWithValue("@id", clsdbo_tbCustomersPara.id);
        try
        {
            connection.Open();
            SqlDataReader reader
                = selectCommand.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
                clsdbo_tbCustomers.id = System.Convert.ToInt32(reader["id"]);
                clsdbo_tbCustomers.TelegramId = System.Convert.ToInt32(reader["TelegramId"]);
                clsdbo_tbCustomers.Fname = reader["Fname"] is DBNull ? null : reader["Fname"].ToString();
                clsdbo_tbCustomers.Lname = reader["Lname"] is DBNull ? null : reader["Lname"].ToString();
                clsdbo_tbCustomers.mobile = reader["mobile"] is DBNull ? null : reader["mobile"].ToString();
                clsdbo_tbCustomers.address = reader["address"] is DBNull ? null : reader["address"].ToString();
            }
            else
            {
                clsdbo_tbCustomers = null;
            }
            reader.Close();
        }
        catch (SqlException ex)
        {
            throw ex;
        }
        finally
        {
            connection.Close();
        }
        return clsdbo_tbCustomers;
    }

    public static bool Add(dbo_tbCustomersClass clsdbo_tbCustomers)
    {
        SqlConnection connection = cmsDataClass.GetConnection();
        string insertStatement
            = "INSERT "
            + "     [dbo].[tbCustomers] "
            + "     ( "
            + "     [TelegramId] "
            + "    ,[Fname] "
            + "    ,[Lname] "
            + "    ,[mobile] "
            + "    ,[address] "
            + "     ) "
            + "VALUES "
            + "     ( "
            + "     @TelegramId "
            + "    ,@Fname "
            + "    ,@Lname "
            + "    ,@mobile "
            + "    ,@address "
            + "     ) "
            + "";
        SqlCommand insertCommand = new SqlCommand(insertStatement, connection);
        insertCommand.CommandType = CommandType.Text;
        insertCommand.Parameters.AddWithValue("@TelegramId", clsdbo_tbCustomers.TelegramId);
        if (clsdbo_tbCustomers.Fname != null)
        {
            insertCommand.Parameters.AddWithValue("@Fname", clsdbo_tbCustomers.Fname);
        }
        else
        {
            insertCommand.Parameters.AddWithValue("@Fname", DBNull.Value);
        }
        if (clsdbo_tbCustomers.Lname != null)
        {
            insertCommand.Parameters.AddWithValue("@Lname", clsdbo_tbCustomers.Lname);
        }
        else
        {
            insertCommand.Parameters.AddWithValue("@Lname", DBNull.Value);
        }
        if (clsdbo_tbCustomers.mobile != null)
        {
            insertCommand.Parameters.AddWithValue("@mobile", clsdbo_tbCustomers.mobile);
        }
        else
        {
            insertCommand.Parameters.AddWithValue("@mobile", DBNull.Value);
        }
        if (clsdbo_tbCustomers.address != null)
        {
            insertCommand.Parameters.AddWithValue("@address", clsdbo_tbCustomers.address);
        }
        else
        {
            insertCommand.Parameters.AddWithValue("@address", DBNull.Value);
        }
        try
        {
            connection.Open();
            int count = insertCommand.ExecuteNonQuery();
            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (SqlException ex)
        {
            throw ex;
        }
        finally
        {
            connection.Close();
        }
    }

    public static bool Update(dbo_tbCustomersClass olddbo_tbCustomersClass,
           dbo_tbCustomersClass newdbo_tbCustomersClass)
    {
        SqlConnection connection = cmsDataClass.GetConnection();
        string updateStatement
            = "UPDATE "
            + "     [dbo].[tbCustomers] "
            + "SET "
            + "     [TelegramId] = @NewTelegramId "
            + "    ,[Fname] = @NewFname "
            + "    ,[Lname] = @NewLname "
            + "    ,[mobile] = @Newmobile "
            + "    ,[address] = @Newaddress "
            + "WHERE "
            + "     [id] = @Oldid "
            + " AND [TelegramId] = @OldTelegramId "
            + " AND ((@OldFname IS NULL AND [Fname] IS NULL) OR [Fname] = @OldFname) "
            + " AND ((@OldLname IS NULL AND [Lname] IS NULL) OR [Lname] = @OldLname) "
            + " AND ((@Oldmobile IS NULL AND [mobile] IS NULL) OR [mobile] = @Oldmobile) "
            + " AND ((@Oldaddress IS NULL AND [address] IS NULL) OR [address] = @Oldaddress) "
            + "";
        SqlCommand updateCommand = new SqlCommand(updateStatement, connection);
        updateCommand.CommandType = CommandType.Text;
        updateCommand.Parameters.AddWithValue("@NewTelegramId", newdbo_tbCustomersClass.TelegramId);
        if (newdbo_tbCustomersClass.Fname != null)
        {
            updateCommand.Parameters.AddWithValue("@NewFname", newdbo_tbCustomersClass.Fname);
        }
        else
        {
            updateCommand.Parameters.AddWithValue("@NewFname", DBNull.Value);
        }
        if (newdbo_tbCustomersClass.Lname != null)
        {
            updateCommand.Parameters.AddWithValue("@NewLname", newdbo_tbCustomersClass.Lname);
        }
        else
        {
            updateCommand.Parameters.AddWithValue("@NewLname", DBNull.Value);
        }
        if (newdbo_tbCustomersClass.mobile != null)
        {
            updateCommand.Parameters.AddWithValue("@Newmobile", newdbo_tbCustomersClass.mobile);
        }
        else
        {
            updateCommand.Parameters.AddWithValue("@Newmobile", DBNull.Value);
        }
        if (newdbo_tbCustomersClass.address != null)
        {
            updateCommand.Parameters.AddWithValue("@Newaddress", newdbo_tbCustomersClass.address);
        }
        else
        {
            updateCommand.Parameters.AddWithValue("@Newaddress", DBNull.Value);
        }
        updateCommand.Parameters.AddWithValue("@Oldid", olddbo_tbCustomersClass.id);
        updateCommand.Parameters.AddWithValue("@OldTelegramId", olddbo_tbCustomersClass.TelegramId);
        if (olddbo_tbCustomersClass.Fname != null)
        {
            updateCommand.Parameters.AddWithValue("@OldFname", olddbo_tbCustomersClass.Fname);
        }
        else
        {
            updateCommand.Parameters.AddWithValue("@OldFname", DBNull.Value);
        }
        if (olddbo_tbCustomersClass.Lname != null)
        {
            updateCommand.Parameters.AddWithValue("@OldLname", olddbo_tbCustomersClass.Lname);
        }
        else
        {
            updateCommand.Parameters.AddWithValue("@OldLname", DBNull.Value);
        }
        if (olddbo_tbCustomersClass.mobile != null)
        {
            updateCommand.Parameters.AddWithValue("@Oldmobile", olddbo_tbCustomersClass.mobile);
        }
        else
        {
            updateCommand.Parameters.AddWithValue("@Oldmobile", DBNull.Value);
        }
        if (olddbo_tbCustomersClass.address != null)
        {
            updateCommand.Parameters.AddWithValue("@Oldaddress", olddbo_tbCustomersClass.address);
        }
        else
        {
            updateCommand.Parameters.AddWithValue("@Oldaddress", DBNull.Value);
        }
        try
        {
            connection.Open();
            int count = updateCommand.ExecuteNonQuery();
            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (SqlException ex)
        {
            throw ex;
        }
        finally
        {
            connection.Close();
        }
    }

    public static bool Delete(dbo_tbCustomersClass clsdbo_tbCustomers)
    {
        SqlConnection connection = cmsDataClass.GetConnection();
        string deleteStatement
            = "DELETE FROM "
            + "     [dbo].[tbCustomers] "
            + "WHERE "
            + "     [id] = @Oldid "
            + " AND [TelegramId] = @OldTelegramId "
            + " AND ((@OldFname IS NULL AND [Fname] IS NULL) OR [Fname] = @OldFname) "
            + " AND ((@OldLname IS NULL AND [Lname] IS NULL) OR [Lname] = @OldLname) "
            + " AND ((@Oldmobile IS NULL AND [mobile] IS NULL) OR [mobile] = @Oldmobile) "
            + " AND ((@Oldaddress IS NULL AND [address] IS NULL) OR [address] = @Oldaddress) "
            + "";
        SqlCommand deleteCommand = new SqlCommand(deleteStatement, connection);
        deleteCommand.CommandType = CommandType.Text;
        deleteCommand.Parameters.AddWithValue("@Oldid", clsdbo_tbCustomers.id);
        deleteCommand.Parameters.AddWithValue("@OldTelegramId", clsdbo_tbCustomers.TelegramId);
        if (clsdbo_tbCustomers.Fname != null)
        {
            deleteCommand.Parameters.AddWithValue("@OldFname", clsdbo_tbCustomers.Fname);
        }
        else
        {
            deleteCommand.Parameters.AddWithValue("@OldFname", DBNull.Value);
        }
        if (clsdbo_tbCustomers.Lname != null)
        {
            deleteCommand.Parameters.AddWithValue("@OldLname", clsdbo_tbCustomers.Lname);
        }
        else
        {
            deleteCommand.Parameters.AddWithValue("@OldLname", DBNull.Value);
        }
        if (clsdbo_tbCustomers.mobile != null)
        {
            deleteCommand.Parameters.AddWithValue("@Oldmobile", clsdbo_tbCustomers.mobile);
        }
        else
        {
            deleteCommand.Parameters.AddWithValue("@Oldmobile", DBNull.Value);
        }
        if (clsdbo_tbCustomers.address != null)
        {
            deleteCommand.Parameters.AddWithValue("@Oldaddress", clsdbo_tbCustomers.address);
        }
        else
        {
            deleteCommand.Parameters.AddWithValue("@Oldaddress", DBNull.Value);
        }
        try
        {
            connection.Open();
            int count = deleteCommand.ExecuteNonQuery();
            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (SqlException ex)
        {
            throw ex;
        }
        finally
        {
            connection.Close();
        }
    }

}

public class dbo_tbCustomersClass
{
    internal string address;
    internal string Fname;
    internal int id;
    internal string Lname;
    internal string mobile;
    internal int TelegramId;
}