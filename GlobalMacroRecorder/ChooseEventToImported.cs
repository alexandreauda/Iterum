using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using MouseKeyboardLibrary;
using System.Threading;
using System.Speech.Recognition;
using System.IO;
using System.Xml.Serialization;

namespace GlobalMacroRecorder
{
    public partial class ChooseEventToImported : Form
    {
        #region ATTRIBUTES
        /****************** ATTRIBUTES ******************/
        private MacroForm m_MacroForm;
        private int m_numberID;
        private List<System.Windows.Forms.CheckBox> m_listOfCheckBox;

        #endregion


        #region CONSTRUCTOR
        /****************** CONSTRUCTOR ******************/
        public ChooseEventToImported(MacroForm MacroForm)
        {
            InitializeComponent();//Initialize the Form

            #region Initialize attributes

            #region Initialize primitive attributes
            //Initialize attributes
            m_MacroForm = MacroForm;
            m_numberID = 0;
            m_listOfCheckBox = new List<System.Windows.Forms.CheckBox>();
            #endregion

            #endregion

            #region For each CheckBox in the MacroForm, create a CheckBox dynamically

            //For each CheckBox in the MacroForm, create a CheckBox dynamically
            foreach (RadioButton element in MacroForm.getm_listOfRadioButton())
            {
                #region Create new CheckBox variable, set it is name dynamically and update variable
                //Create new CheckBox dynamically
                m_numberID++;//Increment the number of event
                System.Windows.Forms.CheckBox radb = new System.Windows.Forms.CheckBox();//Create a CheckBox
                radb.Text = "Event" + m_numberID;//Set the text of CheckBox with the name Event following by the number of events
                Point lastLocationCheckBox = new System.Drawing.Point(0, 0);//Create a variable of type Point
                #endregion

                #region Store in the variable lastLocationCheckBox the location of the last CheckBox.
                //For each component in ScrollPanel of ChooseEventToImported Form, we store the last location of checkbox
                foreach (object o in ScrollPanel.Controls)
                {
                    //If the component is a RadioButton (i.e: If the type of component is a CheckBox).
                    if (o is System.Windows.Forms.CheckBox)
                    {
                        System.Windows.Forms.CheckBox currentCheckBox = (System.Windows.Forms.CheckBox)o;//Stock the component (which is a RadioButton) on a variable called currentRadioButton.
                        lastLocationCheckBox = currentCheckBox.Location;//Set the variable lastLocationCheckBox with the location of the current CheckBox.
                    }
                }
                #endregion

                #region Set the position of the new CheckBox
                //If it is the first record
                if (m_numberID == 1)
                {
                    radb.Location = new System.Drawing.Point(10, 0);//Set the position of CheckBox in the ChooseEventToImported Form
                }
                //If it is not the first record
                else
                {
                    radb.Location = new System.Drawing.Point(10, lastLocationCheckBox.Y + 30);//Set the position of CheckBox in the ChooseEventToImported Form
                }
                #endregion

                radb.Checked = true;//Check current CheckBox.

                #region Add the new CheckBox to the ScrollPanel
                ScrollPanel.Controls.Add(radb);//Add CheckBox in panel called ScrollPanel in ChooseEventToImported Form
                #endregion

                #region Add the new CheckBox to the list m_listOfCheckBox
                m_listOfCheckBox.Add(radb);//Add the new CheckBox to the list m_listOfCheckBox
                #endregion
            }

            #endregion
        }
        #endregion


        #region GETTER
        /****************** GETTER ******************/
        //Get the attribute m_listOfCheckBox
        public List<System.Windows.Forms.CheckBox> getm_listOfCheckBox()
        {
            return m_listOfCheckBox;
        }

        //Get the CheckBox by its id
        public System.Windows.Forms.CheckBox getCheckBoxByEventId(int idOfEvent)
        {
            #region try to get the checkBox of event idOfEvent
            //try to get the checkBox of event idOfEvent
            try
            {
                return m_listOfCheckBox[idOfEvent--];
            }
            //Otherwise, try to get the CheckBox of event 1
            catch
            {
                try
                {
                    return m_listOfCheckBox[1];
                }
                //Otherwise, return null
                catch
                {
                    return null;
                }
            }
            #endregion
        }
        #endregion


        #region METHODS
        /****************** METHODS ******************/
        #region Methods to check/uncheck a CheckBox by its event id

        #region Methods to uncheck a CheckBox by its event id
        //Uncheck a CheckBox by its event id
        public void UncheckCheckBoxByItsEventId(int idOfEvent)
        {
            getCheckBoxByEventId(idOfEvent).Checked = false;
        }
        #endregion

        #region Methods to check a CheckBox by its event id
        //Check a CheckBox by its event id
        public void CheckCheckBoxByItsEventId(int idOfEvent)
        {
            getCheckBoxByEventId(idOfEvent).Checked = true;
        }
        #endregion

        #endregion

        #endregion

        private void checkAllButton_Click(object sender, EventArgs e)
        {
            #region Check all CheckBox
            //For each component in ScrollPanel of ChooseEventToImported Form, we check all CheckBox
            foreach (object o in ScrollPanel.Controls)
            {
                //If the component is a CheckBox (i.e: If the type of component is a CheckBox).
                if (o is System.Windows.Forms.CheckBox)
                {
                    System.Windows.Forms.CheckBox currentCheckBox = (System.Windows.Forms.CheckBox)o;//Stock the component (which is a CheckBox) on a variable called currentCheckBox.
                    //If the current CheckBox is unchecked
                    if (currentCheckBox.Checked == false)
                    {
                        currentCheckBox.Checked = true;//Check all CheckBox.
                    }
                }
            }
            #endregion
        }

        private void uncheckAllButton_Click(object sender, EventArgs e)
        {
            #region Uncheck all CheckBox
            //For each component in ScrollPanel of ChooseEventToImported Form, we uncheck all CheckBox
            foreach (object o in ScrollPanel.Controls)
            {
                //If the component is a CheckBox (i.e: If the type of component is a CheckBox).
                if (o is System.Windows.Forms.CheckBox)
                {
                    System.Windows.Forms.CheckBox currentCheckBox = (System.Windows.Forms.CheckBox)o;//Stock the component (which is a CheckBox) on a variable called currentCheckBox.
                    //If the current CheckBox is checked
                    if (currentCheckBox.Checked == true)
                    {
                        currentCheckBox.Checked = false;//Uncheck all CheckBox.
                    }
                }
            }
            #endregion
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();//Close the ChooseEventToImport Form
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            #region Verify the CheckBox which are checked and store the id of CheckBox which are checked
            int idOfCheckBox = 0;
            //For each component in ScrollPanel of ChooseEventToImported Form, store the id of CheckBox which are checked
            foreach (object o in ScrollPanel.Controls)
            {
                //If the component is a CheckBox (i.e: If the type of component is a CheckBox).
                if (o is System.Windows.Forms.CheckBox)
                {
                    System.Windows.Forms.CheckBox currentCheckBox = (System.Windows.Forms.CheckBox)o;//Stock the component (which is a CheckBox) on a variable called currentCheckBox.
                    //If the current CheckBox is checked
                    if (currentCheckBox.Checked == true)
                    {
                        m_MacroForm.setm_listOfEventsChosenToExport(idOfCheckBox);//Add id of CheckBox which are checked in m_listOfEventsChosenToExport attributes.
                    }
                }
                idOfCheckBox++;
            }
            #endregion
            this.Close();//Close the ChooseEventToImport Form
        }
    }
}
