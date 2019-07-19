using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Speech.Recognition.SrgsGrammar;
using System.Speech.Recognition;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;
using System.Drawing;

namespace GlobalMacroRecorder
{
    [Serializable]
    public class KeysEventArgsSerializable
    {
        #region ATTRIBUTES
        /****************** ATTRIBUTES ******************/
        //
        // Résumé :
        //     Obtient une valeur indiquant si la touche ALT a été activée.
        //
        // Retourne :
        //     true si la touche ALT était activée ; sinon, false.
        private bool m_Alt;
        //
        // Résumé :
        //     Obtient une valeur indiquant si la touche CTRL a été activée.
        //
        // Retourne :
        //     true si la touche CTRL était activée ; sinon, false.
        private bool m_Control;
        //
        // Résumé :
        //     Obtient ou définit une valeur indiquant si l'événement a été géré.
        //
        // Retourne :
        //     true pour ignorer la gestion par défaut du contrôle ; sinon, false pour également
        //     passer l'événement au gestionnaire de contrôle par défaut.
        private bool m_Handled;
        //
        // Résumé :
        //     Obtient le code de clavier d'un événement System.Windows.Forms.Control.KeyDown
        //     ou System.Windows.Forms.Control.KeyUp.
        //
        // Retourne :
        //     Une valeur System.Windows.Forms.Keys représentant le code de touche pour l'événement.
        private Keys m_KeyCode;
        //
        // Résumé :
        //     Obtient la valeur de clavier d'un événement System.Windows.Forms.Control.KeyDown
        //     ou System.Windows.Forms.Control.KeyUp.
        //
        // Retourne :
        //     La représentation sous forme d'entier de la propriété System.Windows.Forms.KeyEventArgs.KeyCode.
        private int m_KeyValue;
        //
        // Résumé :
        //     Obtient les données de touches d'un événement System.Windows.Forms.Control.KeyDown
        //     ou System.Windows.Forms.Control.KeyUp.
        //
        // Retourne :
        //     System.Windows.Forms.Keys représentant le code de touche correspondant à la touche
        //     activée, associée à des indicateurs de touches de modification précisant les
        //     touches CTRL, MAJ et ALT sur lesquelles l'utilisateur a appuyé simultanément.
        private Keys m_KeyData;
        //
        // Résumé :
        //     Obtient les indicateurs de touches de modification d'un événement System.Windows.Forms.Control.KeyDown
        //     ou System.Windows.Forms.Control.KeyUp. Les indicateurs indiquent la combinaison
        //     de touches CTRL, MAJ et ALT activée.
        //
        // Retourne :
        //     Une valeur System.Windows.Forms.Keys représentant un ou plusieurs indicateurs
        //     de touches de modification.
        private Keys m_Modifiers;
        //
        // Résumé :
        //     Obtient une valeur indiquant si la touche MAJ a été activée.
        //
        // Retourne :
        //     true si la touche MAJ était activée ; sinon, false.
        private bool m_Shift;
        //
        // Résumé :
        //     Obtient ou définit une valeur indiquant si l'événement de touche doit être transmis
        //     au contrôle sous-jacent.
        //
        // Retourne :
        //     true si l'événement de touche ne doit pas être transmis au contrôle ; sinon,
        //     false.
        private bool m_SuppressKeyPress;
        #endregion


        #region CONSTRUCTOR
        /****************** CONSTRUCTOR ******************/
        public KeysEventArgsSerializable() { }

        //
        // Résumé :
        //     Initialise une nouvelle instance de la classe System.Windows.Forms.KeyEventArgs.
        //
        // Paramètres :
        //   keyData:
        //     System.Windows.Forms.Keys correspondant à la touche activée, associée à des indicateurs
        //     de touches de modification précisant les touches CTRL, MAJ et ALT sur lesquelles
        //     l'utilisateur a appuyé simultanément. Les valeurs possibles sont obtenues en
        //     appliquant l'opérateur de bits OR (|) à des constantes à partir de l'énumération
        //     System.Windows.Forms.Keys.
        public KeysEventArgsSerializable(Keys keyData)
        {
            m_KeyData = keyData;
        }
        #endregion

        #region GETTER
        /****************** GETTER ******************/
        //Get the attribute m_Alt
        public bool getm_Alt()
        {
            return m_Alt;//Return the attribute m_Alt
        }

        //Get the attribute m_Control
        public bool getm_Control()
        {
            return m_Control;//Return the attribute m_Control
        }

        //Get the attribute m_Handled
        public bool getm_Handled()
        {
            return m_Handled;//Return the attribute m_Handled
        }

        //Get the attribute m_KeyCode
        public Keys getm_KeyCode()
        {
            return m_KeyCode;//Return the attribute m_KeyCode
        }

        //Get the attribute m_KeyValue
        public int getm_KeyValue()
        {
            return m_KeyValue;//Return the attribute m_KeyValue
        }

        //Get the attribute m_KeyData
        public Keys getm_KeyData()
        {
            return m_KeyData;//Return the attribute m_KeyData
        }

        //Get the attribute m_Modifiers
        public Keys getm_Modifiers()
        {
            return m_Modifiers;//Return the attribute m_Modifiers
        }

        //Get the attribute m_Shift
        public bool getm_Shift()
        {
            return m_Shift;//Return the attribute m_Shift
        }

        //Get the attribute m_SuppressKeyPress
        public bool getm_SuppressKeyPress()
        {
            return m_SuppressKeyPress;//Return the attribute m_SuppressKeyPress
        }
        #endregion

        #region SETTER
        /****************** SETTER ******************/
        //Set the attribute m_Alt
        public void setm_Alt(bool Alt)
        {
            m_Alt = Alt;//Set the attribute m_Alt
        }

        //Set the attribute m_Control
        public void setm_Control(bool Control)
        {
            m_Control = Control;//Set the attribute m_Control
        }

        //Set the attribute m_Handled
        public void setm_Handled(bool Handled)
        {
            m_Handled = Handled;//Set the attribute m_Handled
        }

        //Set the attribute m_KeyCode
        public void setm_KeyCode(Keys KeyCode)
        {
            m_KeyCode = KeyCode;//Set the attribute m_KeyCode
        }

        //Set the attribute m_KeyValue
        public void setm_KeyValue(Keys KeyValue)
        {
            m_KeyData = KeyValue;//Set the attribute m_KeyValue
        }

        //Set the attribute m_KeyData
        public void setm_KeyData(Keys KeyData)
        {
            m_KeyData = KeyData;//Set the attribute m_KeyData
        }

        //Set the attribute m_Modifiers
        public void setm_Modifiers(Keys Modifiers)
        {
            m_Modifiers = Modifiers;//Set the attribute m_Modifiers
        }

        //Set the attribute m_Shift
        public void setm_Shift(bool Shift)
        {
            m_Shift = Shift;//Set the attribute m_Shift
        }

        //Set the attribute m_SuppressKeyPress
        public void setm_SuppressKeyPress(bool SuppressKeyPress)
        {
            m_SuppressKeyPress = SuppressKeyPress;//Set the attribute m_SuppressKeyPress
        }
        #endregion

        #region METHODS

        /****************** METHODS ******************/
        #region Methods 1
        // Methods 1
        private void method1(object sender, SpeechHypothesizedEventArgs e)
        {
            //Write here
        }
        #endregion

        #endregion
    }

}