package models;

import java.io.*;
import java.util.ArrayList;

public class ContactList extends ArrayList<Contact>
{
    public static void Save(ContactList contacts, String filePath) throws FileNotFoundException, IOException
    {
        try (ObjectOutputStream oos = new ObjectOutputStream(new FileOutputStream(filePath)))
        {
            oos.writeObject(contacts);
        }
    }
    public static ContactList Load(String filePath) throws FileNotFoundException, IOException
    {
        ContactList contacts = null;
        try(ObjectInputStream ois = new ObjectInputStream(new FileInputStream(filePath)))
        {
            contacts = ((ContactList) ois.readObject());
        }
        catch (ClassNotFoundException ex)
        {
            System.err.println(ex.getMessage());
        }

        return contacts;
    }
}
