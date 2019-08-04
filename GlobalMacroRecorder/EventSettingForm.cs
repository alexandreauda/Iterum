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
    public partial class EventSettingForm : Form
    {
        #region ATTRIBUTES
        /****************** ATTRIBUTES ******************/
        private MacroForm m_MacroForm;
        private int m_numberID_RadioButtonOptionSpeed;

        #endregion


        #region CONSTRUCTOR
        /****************** CONSTRUCTOR ******************/
        public EventSettingForm(MacroForm MacroForm)
        {
            InitializeComponent();//Initialize the Form

            #region Initialize attributes

            #region Initialize primitive attributes
            //Initialize attributes
            m_MacroForm = MacroForm;
            m_numberID_RadioButtonOptionSpeed = 1;
            #endregion

            #endregion
        }
        #endregion


        #region GETTER
        /****************** GETTER ******************/
        //Get the attribute m_numberID_RadioButtonOptionSpeed
        public int getm_numberID_RadioButtonOptionSpeed()
        {
            return m_numberID_RadioButtonOptionSpeed;
        }
        #endregion

        #region METHODS
        /****************** METHODS ******************/
        #region Methods to enable the current group chosen and disable the others

        //Enable the current group chosen and disable the other groups
        private void enableOnlyCurrentGroup()
        {
            #region Enable the current group chosen and disable the other groups
            if (m_numberID_RadioButtonOptionSpeed == 1)
            {
                groupBoxNormalSpeed.Enabled = true;
                groupBoxCustomMultiplierSpeed.Enabled = false;
                groupBoxCustomUniformSpeed.Enabled = false;
                groupBoxFullCustomSpeed.Enabled = false;
            }
            if (m_numberID_RadioButtonOptionSpeed == 2)
            {
                groupBoxNormalSpeed.Enabled = false;
                groupBoxCustomMultiplierSpeed.Enabled = true;
                groupBoxCustomUniformSpeed.Enabled = false;
                groupBoxFullCustomSpeed.Enabled = false;
            }
            if (m_numberID_RadioButtonOptionSpeed == 3)
            {
                groupBoxNormalSpeed.Enabled = false;
                groupBoxCustomMultiplierSpeed.Enabled = false;
                groupBoxCustomUniformSpeed.Enabled = true;
                groupBoxFullCustomSpeed.Enabled = false;
            }
            if (m_numberID_RadioButtonOptionSpeed == 4)
            {
                groupBoxNormalSpeed.Enabled = false;
                groupBoxCustomMultiplierSpeed.Enabled = false;
                groupBoxCustomUniformSpeed.Enabled = false;
                groupBoxFullCustomSpeed.Enabled = true;
            }
            #endregion
        }
        #endregion

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();//Close the ChooseEventsToExport Form
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            bool isValideToClose = false;
            switch (m_numberID_RadioButtonOptionSpeed)
            {
                case 1:
                    m_MacroForm.setm_listEventsWithSettingWithNormalSpeed();
                    isValideToClose = true;
                    break;

                case 2:
                    bool divideSpeed = false;
                    if (trackBarChooseOperand.Value == 1)
                    {
                        divideSpeed = false;
                    }
                    else
                    {
                        divideSpeed = true;
                    }
                    string inputCustomMultiplierTimeSpeed = numericUpDownMultiplierTimeSpeed.Text;
                    int resultCustomMultiplierTimeSpeed = 2;
                    try
                    {
                        resultCustomMultiplierTimeSpeed = Int32.Parse(inputCustomMultiplierTimeSpeed);//Try to transform the entry of inputCustomMultiplierTimeSpeed textbox in integer
                        int resultOfSetCustomMultiplierSpeed = m_MacroForm.setm_listEventsWithSettingWithCustomMultiplierSpeed(divideSpeed, resultCustomMultiplierTimeSpeed);//Set the time speed multiplier with the entry of numericUpDownMultiplierTimeSpeed textbox
                        if(resultOfSetCustomMultiplierSpeed == 1)
                        {
                            isValideToClose = true;
                        }
                    }
                    //If we cannot transform the entry of numericUpDownMultiplierTimeSpeed textbox in integer, we create a error message box to inform the user and we don't close windows.
                    catch (FormatException)
                    {
                        numericUpDownMultiplierTimeSpeed.Text = "2";
                        #region If we cannot transform the entry of numericUpDownMultiplierTimeSpeed textbox in integer, we create a error message box to inform the user and we don't close windows.
                        // Configure the message box to be displayed
                        string messageBoxText = "The time speed of event must be an integer. Please, enter an integer for the time speed multiplier of event. The more the time speed is bigger, the more the playback will be play slowly.";
                        string caption = "Error";
                        MessageBoxButtons button = MessageBoxButtons.OK;
                        MessageBoxIcon icon = MessageBoxIcon.Error;
                        MessageBox.Show(messageBoxText, caption, button, icon);//Show message box error to inform user.
                        #endregion
                    }
                    break;

                case 3:
                    string inputCustomUniformSpeed = NumericUpDownUniformSpeed.Text;
                    int resultCustomUniformSpeed = 0;
                    try
                    {
                        resultCustomUniformSpeed = Int32.Parse(inputCustomUniformSpeed);//Try to transform the entry of NumericUpDownUniformSpeed textbox in integer
                        m_MacroForm.setm_listEventsWithSettingWithCustomUniformSpeed(resultCustomUniformSpeed);//Set the speed with the entry of NumericUpDownUniformSpeed textbox
                        isValideToClose = true;//Set the variable to close the EventSettingForm Form.
                    }
                    //If we cannot transform the entry of NumericUpDownUniformSpeed textbox in integer, we create a error message box to inform the user and we don't close windows.
                    catch (FormatException)
                    {
                        NumericUpDownUniformSpeed.Text = "0";
                        #region If we cannot transform the entry of NumericUpDownUniformSpeed textbox in integer, we create a error message box to inform the user and we don't close windows.
                        // Configure the message box to be displayed
                        string messageBoxText = "The time speed of event must be an integer. Please, enter an integer for the time speed of event. An event with a time speed equal to 0 will be playback instantaneous and the more the time speed is bigger, the more the playback will be play slowly.";
                        string caption = "Error";
                        MessageBoxButtons button = MessageBoxButtons.OK;
                        MessageBoxIcon icon = MessageBoxIcon.Error;
                        MessageBox.Show(messageBoxText, caption, button, icon);//Show message box error to inform user that the speed of an event connot be faster than instantaneous
                        #endregion
                    }
                    break;

                case 4:
                    isValideToClose = true;
                    break;
            }
            //if isValideToClose is equal to true then close EventSettingForm else do not close EventSettingForm form.
            if(isValideToClose)
            {
                this.Close();//Close the ChooseEventsToExport Form
            }
        }

        private void radioButtonNormalSpeed_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonNormalSpeed.Checked == true)
            {
                m_numberID_RadioButtonOptionSpeed = 1;
                enableOnlyCurrentGroup();//Enable the current group chosen and disable the other groups
                okButton.Focus();//Set the focus on okButton button.
            }
        }

        private void radioButtonCustomMultiplierSpeed_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonCustomMultiplierSpeed.Checked == true)
            {
                m_numberID_RadioButtonOptionSpeed = 2;
                enableOnlyCurrentGroup();//Enable the current group chosen and disable the other groups
                numericUpDownMultiplierTimeSpeed.Focus();//Set the focus on numericUpDownMultiplierTimeSpeed button.
            }
        }

        private void radioButtonCustomUniformSpeed_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonCustomUniformSpeed.Checked == true)
            {
                m_numberID_RadioButtonOptionSpeed = 3;
                enableOnlyCurrentGroup();//Enable the current group chosen and disable the other groups
                NumericUpDownUniformSpeed.Focus();//Set the focus on NumericUpDownUniformSpeed.
            }
        }

        private void radioButtonFullCustomSpeed_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonFullCustomSpeed.Checked == true)
            {
                m_numberID_RadioButtonOptionSpeed = 4;
                enableOnlyCurrentGroup();//Enable the current group chosen and disable the other groups
            }
        }

        private void numericUpDownMultiplierTimeSpeed_enterInput(object sender, KeyEventArgs e)
        {
            //If the user press the enter touch of keyboard when the numericUpDownMultiplierTimeSpeed have the focus, press the Ok button of EventSettingForm Form.
            if (e.KeyValue == 13)
            {
                okButton.PerformClick();//Press the Ok button of EventSettingForm Form.
            }
        }

        private void NumericUpDownUniformSpeed_enterInput(object sender, KeyEventArgs e)
        {
            //If the user press the enter touch of keyboard when the NumericUpDownUniformSpeed have the focus, press the Ok button of EventSettingForm Form.
            if (e.KeyValue == 13)
            {
                okButton.PerformClick();//Press the Ok button of EventSettingForm Form.
            }
        }
        #endregion
    }
}
