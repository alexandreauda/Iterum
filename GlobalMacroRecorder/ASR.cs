using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Speech.Recognition.SrgsGrammar;
using System.Speech.Recognition;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;

namespace GlobalMacroRecorder
{
    class ASR
    {
        #region ATTRIBUTES
        /****************** ATTRIBUTES ******************/
        private SpeechRecognitionEngine m_ASREngine;
        private MacroForm m_mainWindowIterum;
        #endregion


        #region CONSTRUCTOR
        /****************** CONSTRUCTOR ******************/
        // Constructor of ASR (Automatic Speech Recognition)
        public ASR(MacroForm mainWindowIterum)
        {
            m_mainWindowIterum = mainWindowIterum;//Initialise member attributes
            StartEngine();//Start the speech Recognition Engine
        }


        // Start the speech recognition engine and load of grammar file according the language of current system
        private void StartEngine()
        {
            #region Choose the grammar according to the language system
            String stringCurrentCulture = Thread.CurrentThread.CurrentCulture.Name;
            String nameOfGrammarLoaded = "";

            if (stringCurrentCulture == "fr-FR")
            {
                nameOfGrammarLoaded = "Grammar/GrammarIterumFR.grxml";
            }
            else if (stringCurrentCulture == "en-US")
            {
                nameOfGrammarLoaded = "Grammar/GrammarIterumEN.grxml";
            }
            else
            {
                nameOfGrammarLoaded = "Grammar/GrammarIterumFR.grxml";
            }
            #endregion

            #region Set the speech recognization engine
            SrgsDocument xmlGrammar = new SrgsDocument(nameOfGrammarLoaded);//Creation of file in the norme SRGS from the grammar file in format grxml
            Grammar grammar = new Grammar(xmlGrammar);//Creation of grammar from the the grammar file in format grxml
            m_ASREngine = new SpeechRecognitionEngine(new CultureInfo(stringCurrentCulture));//Creation of object SpeechRecognitionEngine in the language of the current system
            try
            {
                m_ASREngine.SetInputToDefaultAudioDevice();//Get the sound by microphone default
            }
            catch (Exception e)
            {
                #region If we cannot get the sound by microphone default. So, we create a error message box.
                // Configure the message box to be displayed
                string messageBoxText = "Cannot get the sound by microphone default. Turn on your microphone to use the speech recognition.";
                string caption = "Error";
                MessageBoxButtons button = MessageBoxButtons.OK;
                MessageBoxIcon icon = MessageBoxIcon.Error;
                MessageBox.Show(messageBoxText, caption, button, icon);//Show message box error to inform user that the metod EventSettingButton_Click fail
                #endregion
            }
            m_ASREngine.LoadGrammar(grammar);//Load grammar
            m_ASREngine.SpeechRecognized += ASREngine_SpeechRecognized;//Handle the SpeechRecognized method by the ASR engine
            m_ASREngine.SpeechRecognitionRejected += ASREngine_SpeechRecognitionRejected;//Handle the SpeechRecognitionRejected method by the ASR engine
            m_ASREngine.SpeechHypothesized += ASREngine_SpeechHypothesized;//Handle the SpeechHypothesized method by the ASR engine
            m_ASREngine.MaxAlternates = 4;//Specify of max alternates. For example b or p or d or t; t or d; i or j, etc. Usefull for the sound which is similar
            #endregion
        }
        #endregion


        #region GETTER
        /****************** GETTER ******************/
        //Get the attribute m_ASR
        public SpeechRecognitionEngine getm_ASR()
        {
            return m_ASREngine;//Return the attribute m_ASR
        }
        #endregion


        #region METHODS

        /****************** METHODS ******************/
        #region Methods relative to speech recognition
        // Method used when the speech recognition is in progress
        private void ASREngine_SpeechHypothesized(object sender, SpeechHypothesizedEventArgs e)
        {
            //Write here
        }


        // Method used when the speech recognition fail
        private void ASREngine_SpeechRecognitionRejected(object sender, SpeechRecognitionRejectedEventArgs e)
        {
            //Write here
        }


        // Method used when the speech recognition sucess
        private void ASREngine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            #region Method used when the speech recognition sucess

            String resultStringASR = e.Result.Text.ToString();//Text of type string recognize by ASR engine when the speech recognition sucess

            string baseCommand = e.Result.Semantics["mouskie"].Value.ToString();//Get the base command used. Here, if the first key words is "Ok iterum" then its associate value is equal to "LEARN".

            //if the string baseCommand is equal to "LEARN"
            if (baseCommand.Equals("LEARN"))
            {
                string dataType = e.Result.Semantics["data_type"].Value.ToString();//Get the second command used.

                //if the second key words has a associate value equal to "EXIT" (in the grammar loaded)
                if (dataType.Equals("EXIT"))
                {
                    Environment.Exit(0);//Close application
                }
                //if the second key words has a associate value equal to "START" (in the grammar loaded)
                else if (dataType.Equals("START"))
                {
                    m_mainWindowIterum.recordStartButton_Click(null, EventArgs.Empty);//Call the method called by the start button
                }
                //if the second key words has a associate value equal to "STOP" (in the grammar loaded)
                else if (dataType.Equals("STOP"))
                {
                    m_mainWindowIterum.Activate();
                    m_mainWindowIterum.recordStopButton_Click(null, EventArgs.Empty);//Call the method called by the stop button
                }
                //if the second key words has a associate value equal to "SLEEP" (in the grammar loaded)
                else if (dataType.Equals("SLEEP"))
                {
                    m_mainWindowIterum.speechButton_Click(null, EventArgs.Empty);//Call the method called by the speech button
                }
                //if the second key words has a associate value equal to "IMPORT" (in the grammar loaded)
                else if (dataType.Equals("IMPORT"))
                {
                    m_mainWindowIterum.ImportSeveralEventsButton_Click(null, EventArgs.Empty);//Call the method called by the speech button
                }
                //if the second key words has a associate value equal to "EXPORT" (in the grammar loaded)
                else if (dataType.Equals("EXPORT"))
                {
                    m_mainWindowIterum.ExportSeveralEventsButton_Click(null, EventArgs.Empty);//Call the method called by the speech button
                }
                //if the second key words has a associate value equal to "SETTING" (in the grammar loaded)
                else if (dataType.Equals("SETTING"))
                {
                    m_mainWindowIterum.EventSettingButton_Click(null, EventArgs.Empty);//Call the method called by the speech button
                }
                //if the second key words has a associate value equal to "PLAYBACK" (in the grammar loaded)
                else if (dataType.Equals("PLAYBACK"))
                {
                    string stringIdOfEventPlayback = e.Result.Words[3].Text;//Get the fourth word because the id of event Playback is normally the fourth word because it recognize the sentence "Ok iterum playback idOfEvent", with idOfEvent equal to 1, 2, 3 or 4, etc...
                    int idOfEventPlayback;
                    try
                    {
                        idOfEventPlayback = Convert.ToInt32(stringIdOfEventPlayback);//Try to convert the string stringIdOfEventPlayback to int. Normally, stringIdOfEventPlayback can be casted to int.

                        try
                        {
                            //if idOfEventPlayback is greater or equal to 1 and not greater to the number of radio button
                            if (idOfEventPlayback <= m_mainWindowIterum.getm_listOfRadioButton().Count && idOfEventPlayback >= 1)
                            {
                                m_mainWindowIterum.checkRadioButtonByItsEventId(idOfEventPlayback);//Check the radio button associate to the event id idOfEventPlayback
                                //try to call the method playBackMacroButton_Click in order to playback the event with the id idOfEventPlayback
                                try
                                {
                                    m_mainWindowIterum.playBackMacroButton_Click(null, EventArgs.Empty);//Call the method playBackMacroButton_Click in order to playback the event with the id idOfEventPlayback
                                }
                                //Otherwise, show a message box error in order to inform user that the metod playBackMacroButton_Click fail
                                catch
                                {
                                    // Configure the message box to be displayed
                                    string messageBoxText = "playBackMacroButton_Click fail!";
                                    string caption = "Action";
                                    MessageBoxButtons button = MessageBoxButtons.OK;
                                    MessageBoxIcon icon = MessageBoxIcon.Error;
                                    MessageBox.Show(messageBoxText, caption, button, icon);//Show message box error to inform user that the metod playBackMacroButton_Click fail
                                }
                            }
                        }
                        //If the method checkRadioButtonByItsEventId fail
                        catch
                        {
                            // Configure the message box to be displayed
                            string messageBoxText = "Check button unsucess!";
                            string caption = "Action";
                            MessageBoxButtons button = MessageBoxButtons.OK;
                            MessageBoxIcon icon = MessageBoxIcon.Error;
                            MessageBox.Show(messageBoxText, caption, button, icon);//Show message box error to inform user that the metod checkRadioButtonByItsEventId fail
                        }
                    }
                    //If Convert.ToInt32(stringIdOfEventPlayback) fail
                    catch
                    {
                        // Configure the message box to be displayed
                        string messageBoxText = "Event id unknow!";
                        string caption = "Action";
                        MessageBoxButtons button = MessageBoxButtons.OK;
                        MessageBoxIcon icon = MessageBoxIcon.Error;
                        MessageBox.Show(messageBoxText, caption, button, icon);//Show message box error to inform user that Event id recognized is unknow
                    }
                }
            }
            
            #endregion
        }
        #endregion

        #region Methods to add item dynamically in the grammar and reload the grammar

        //Add item in the grammar and reload it
        public void addItemInGrammarAndReloadEngine(string nameOfRule, int idOfBalise, string itemToAdd)
        {
            #region Choose the grammar according to the language system
            String stringCurrentCulture = Thread.CurrentThread.CurrentCulture.Name;
            String nameOfGrammarLoaded = "";

            if (stringCurrentCulture == "fr-FR")
            {
                nameOfGrammarLoaded = "Grammar/GrammarIterumFR.grxml";
            }
            else if (stringCurrentCulture == "en-US")
            {
                nameOfGrammarLoaded = "Grammar/GrammarIterumEN.grxml";
            }
            else
            {
                nameOfGrammarLoaded = "Grammar/GrammarIterumFR.grxml";
            }
            #endregion

            #region Add a item in the grammar and reload it
            SrgsDocument xmlGrammar = new SrgsDocument(nameOfGrammarLoaded);//Creation of file in the norme SRGS from the grammar file in format grxml

            addItemInABalise(xmlGrammar, nameOfRule, idOfBalise, itemToAdd);//Method to add item dynamically in the grammar

            Grammar grammar = new Grammar(xmlGrammar);//Creation of grammar from the the grammar file in format grxml
            m_ASREngine.LoadGrammar(grammar);//Load grammar
            #endregion
        }

        //Method to add item dynamically in the grammar
        private void addItemInABalise(SrgsDocument xmlGrammar, string nameOfRule, int idOfBalise, string itemToAdd)
        {
            #region Add item dynamically in the grammar

            //if the balise target by idOfBalise is a "OneOf" balise
            try
            {
                SrgsOneOf oneOfBalise = (SrgsOneOf)xmlGrammar.Rules[nameOfRule].Elements[idOfBalise];
                oneOfBalise.Add(new SrgsItem(itemToAdd));//Add item in the "OneOf" balise
            }
            catch
            {
                //if the balise target by idOfBalise is a "Item" balise
                try
                {
                    SrgsItem itemBalise = (SrgsItem)xmlGrammar.Rules[nameOfRule].Elements[idOfBalise];
                    itemBalise.Add(new SrgsItem(itemToAdd));//Add item in the "Item" balise
                }
                //Otherwise, return a message box error to inform user
                catch
                {
                    // Configure the message box to be displayed
                    string messageBoxText = "In the method addItemInABalise(), it is only possible to add item after a OneOf balise or a Item balise!";
                    string caption = "Error in method addItemInABalise";
                    MessageBoxButtons button = MessageBoxButtons.OK;
                    MessageBoxIcon icon = MessageBoxIcon.Error;
                    MessageBox.Show(messageBoxText, caption, button, icon);// Display message box
                }
            }

            #endregion
        }
        #endregion

        #endregion
    }
}
