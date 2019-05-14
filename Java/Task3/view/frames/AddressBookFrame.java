package view.frames;

import java.awt.*;
import javax.swing.*;
import java.awt.event.*;

public class AddressBookFrame extends JFrame implements view.controlModels.interfaces.DataChangedListener
{
    // CONST
    public static final int DEFAULT_WIDTH = 500;
    public static final int DEFAULT_HEIGHT = 600;

    // FIELDS
    view.controlModels.AddressBookTableModel addressBookTableModel;

    String currentFileName;
    boolean isDataChanged;
    JFileChooser fileChooser;
    JMenuItem saveMi;

    // CONSTRUCTORS
    public AddressBookFrame()
    {
        // sets title and size
        setTitle("Address Book");
        setSize(DEFAULT_WIDTH, DEFAULT_HEIGHT);
        setMinimumSize(new Dimension(DEFAULT_WIDTH, DEFAULT_HEIGHT));

        // get screen dimensions
        Dimension screenSize = Toolkit.getDefaultToolkit().getScreenSize();

        // center frame in screen
        setLocation(screenSize.width/2 - DEFAULT_WIDTH/2, screenSize.height/2 - DEFAULT_HEIGHT/2);

        // initialize fields
        initializeFields();

        // initialize dialogs
        initializeDialogs();

        // add panel to frame
        addressBookTableModel = new view.controlModels.AddressBookTableModel();
        add(new view.panels.TablePanel(addressBookTableModel));

        // add menu
        addMenu();

        // update interface
        updateInterface();

        // add Frame listener
        addListener();
    }
    private void initializeFields()
    {
        isDataChanged = false;
        currentFileName = null;
    }
    private void updateInterface()
    {
        saveMi.setEnabled(isDataChanged);

        updateTitle(!isDataChanged);
    }
    private void updateTitle(boolean isSaved)
    {
        String title = currentFileName == null ? "New document" : currentFileName;
        boolean hasStar = title.contains("*");

        if (isSaved && hasStar)         setTitle(title.substring(0, title.length() - 1)); // remove last char
        else if (!isSaved && !hasStar)  setTitle(title + '*'); // add star
        else                            setTitle(title);
    }
    private void addListener()
    {
        this.setDefaultCloseOperation(JFrame.DO_NOTHING_ON_CLOSE);
        this.addWindowListener(new WindowAdapter()
        {
            public void windowClosing(WindowEvent e)
            {
                exit();
            }
        });

        addressBookTableModel.addDataChangedListener(this);
    }
    private void initializeDialogs()
    {
        fileChooser = new JFileChooser(System.getProperty("user.home") + "/Desktop");
        fileChooser.addChoosableFileFilter(new javax.swing.filechooser.FileFilter()
        {
            public boolean accept(java.io.File f)
            {
                if (f.isDirectory()) return true;
                return f.getName().endsWith(".dat");
            }
            public String getDescription()
            {
                return "Binary file";
            }
        });
        fileChooser.addChoosableFileFilter(new javax.swing.filechooser.FileFilter()
        {
            public boolean accept(java.io.File f)
            {
                if (f.isDirectory()) return true;
                return f.getName().endsWith(".txt");
            }
            public String getDescription()
            {
                return "Text file";
            }
        });
    }
    private void addMenu()
    {
        JMenuBar menuBar = new JMenuBar();

        // File
        JMenu menu = new JMenu("File");

        // - new
        JMenuItem menuItem = new JMenuItem("New");
        menuItem.setIcon(new ImageIcon("Task3/resources/pictograms/new_file_16x16.png"));
        menuItem.setAccelerator(KeyStroke.getKeyStroke(KeyEvent.VK_N, ActionEvent.CTRL_MASK));
        menuItem.addActionListener(new ActionListener()
        {
            public void actionPerformed(ActionEvent e)
            {
                newFile();
            }
        });
        menu.add(menuItem);

        // - open
        menuItem = new JMenuItem("Open");
        menuItem.setIcon(new ImageIcon("Task3/resources/pictograms/open_16x16.png"));
        menuItem.setAccelerator(KeyStroke.getKeyStroke(KeyEvent.VK_O, ActionEvent.CTRL_MASK));
        menuItem.addActionListener(new ActionListener()
        {
            public void actionPerformed(ActionEvent e)
            {
                open();
            }
        });
        menu.add(menuItem);

        menu.addSeparator();

        // - save
        menuItem = new JMenuItem("Save");
        saveMi = menuItem;
        menuItem.setIcon(new ImageIcon("Task3/resources/pictograms/save_16x16.png"));
        menuItem.setAccelerator(KeyStroke.getKeyStroke(KeyEvent.VK_S, ActionEvent.CTRL_MASK));
        menuItem.addActionListener(new ActionListener()
        {
            public void actionPerformed(ActionEvent e)
            {
                save(currentFileName);
            }
        });
        menu.add(menuItem);

        // - save as
        menuItem = new JMenuItem("Save as");
        menuItem.addActionListener(new ActionListener()
        {
            public void actionPerformed(ActionEvent e)
            {
                save(null);
            }
        });
        menuItem.setAccelerator(KeyStroke.getKeyStroke(KeyEvent.VK_S,ActionEvent.CTRL_MASK | ActionEvent.SHIFT_MASK));
        menu.add(menuItem);

        menu.addSeparator();

        // - exit
        menuItem = new JMenuItem("Exit");
        menuItem.setIcon(new ImageIcon("Task3/resources/pictograms/logout_16x16.png"));
        menuItem.setAccelerator(KeyStroke.getKeyStroke(KeyEvent.VK_W, ActionEvent.CTRL_MASK));
        menuItem.addActionListener(new ActionListener()
        {
            public void actionPerformed(ActionEvent e)
            {
                exit();
            }
        });
        menu.add(menuItem);

        menuBar.add(menu);

        // Info
        menu = new JMenu("Info");
        menu.addMouseListener(new MouseAdapter()
        {
            public void mouseClicked(java.awt.event.MouseEvent e)
            {
                JOptionPane.showMessageDialog(AddressBookFrame.this, "Created by Kizlo Taras");
            }
        });
        menuBar.add(menu);

        setJMenuBar(menuBar);
    }

    // METHODS
    private void newFile()
    {
        if (onDocumentClosing() != JOptionPane.CANCEL_OPTION);// maybe save file?
        {
            addressBookTableModel.clear();
            currentFileName = null;
            isDataChanged = false;

            updateInterface();
        }
    }
    private void open()
    {
        int userChoice = onDocumentClosing();// maybe save file?

        if (userChoice != JOptionPane.CANCEL_OPTION &&
                fileChooser.showDialog(AddressBookFrame.this,"Open file") == JFileChooser.APPROVE_OPTION)
        {
            String openedFileName = fileChooser.getSelectedFile().getPath();

            // loading
            try
            {
                addressBookTableModel.setContacts(models.ContactList.Load(openedFileName));
            }
            catch (java.io.FileNotFoundException ex)
            {
                JOptionPane.showMessageDialog(AddressBookFrame.this,  "File not found");
            }
            catch (java.io.IOException ex)
            {
                JOptionPane.showMessageDialog(AddressBookFrame.this,  "Could not read data");
            }
            catch (Exception ex)
            {
                JOptionPane.showMessageDialog(AddressBookFrame.this,  "Something went wrong");
            }

            // remembering data
            currentFileName = openedFileName;
            isDataChanged = false;

            updateInterface();
        }
    }
    // save or save as
    private int save(String fileName)
    {
        if (fileName == null)
        {
            //save as...
            if (fileChooser.showDialog(AddressBookFrame.this,"Save file") == JFileChooser.APPROVE_OPTION)
            {
                fileName = fileChooser.getSelectedFile().getPath();
            }
            else
            {
                return JFileChooser.CANCEL_OPTION;
            }
        }

        // saving
        try
        {
            models.ContactList.Save(addressBookTableModel.getContacts(), fileName);
        }
        catch (java.io.FileNotFoundException ex)
        {
            JOptionPane.showMessageDialog(AddressBookFrame.this,  "File not found");

            return JFileChooser.ERROR_OPTION;
        }
        catch (Exception ex)
        {
            JOptionPane.showMessageDialog(AddressBookFrame.this,  "Something went wrong");

            return JFileChooser.ERROR_OPTION;
        }

        // remember name
        currentFileName = fileName;
        isDataChanged = false;

        // update interface
        updateInterface();

        return JFileChooser.APPROVE_OPTION;
    }
    private int onDocumentClosing()
    {
        if (isDataChanged)
        {
            int userChoice;
            do
            {
                userChoice = JOptionPane.showConfirmDialog(AddressBookFrame.this,  "Save current file?");
                if (userChoice == JOptionPane.CANCEL_OPTION) return JOptionPane.CANCEL_OPTION;

                // save, and break if no exceptions
                if (userChoice == JOptionPane.YES_OPTION && save(currentFileName) != JFileChooser.ERROR_OPTION)
                {
                    return JOptionPane.YES_OPTION;
                }
            } while (userChoice == JOptionPane.YES_OPTION);
        }
        return JOptionPane.NO_OPTION;
    }
    private void exit()
    {
        if (onDocumentClosing() != JOptionPane.CANCEL_OPTION) System.exit(0);
    }
    // Data changed listener
    public void dataChanged()
    {
        isDataChanged = true;

        updateInterface();
    }
}