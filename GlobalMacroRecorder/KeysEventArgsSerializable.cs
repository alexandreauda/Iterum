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
        public virtual bool m_Alt { get; set; }
        //
        // Résumé :
        //     Obtient une valeur indiquant si la touche CTRL a été activée.
        //
        // Retourne :
        //     true si la touche CTRL était activée ; sinon, false.
        public bool m_Control { get; set; }
        //
        // Résumé :
        //     Obtient ou définit une valeur indiquant si l'événement a été géré.
        //
        // Retourne :
        //     true pour ignorer la gestion par défaut du contrôle ; sinon, false pour également
        //     passer l'événement au gestionnaire de contrôle par défaut.
        public bool m_Handled { get; set; }
        //
        // Résumé :
        //     Obtient le code de clavier d'un événement System.Windows.Forms.Control.KeyDown
        //     ou System.Windows.Forms.Control.KeyUp.
        //
        // Retourne :
        //     Une valeur System.Windows.Forms.Keys représentant le code de touche pour l'événement.
        public Keys m_KeyCode { get; set; }
        //
        // Résumé :
        //     Obtient la valeur de clavier d'un événement System.Windows.Forms.Control.KeyDown
        //     ou System.Windows.Forms.Control.KeyUp.
        //
        // Retourne :
        //     La représentation sous forme d'entier de la propriété System.Windows.Forms.KeyEventArgs.KeyCode.
        public int m_KeyValue { get; set; }
        //
        // Résumé :
        //     Obtient les données de touches d'un événement System.Windows.Forms.Control.KeyDown
        //     ou System.Windows.Forms.Control.KeyUp.
        //
        // Retourne :
        //     System.Windows.Forms.Keys représentant le code de touche correspondant à la touche
        //     activée, associée à des indicateurs de touches de modification précisant les
        //     touches CTRL, MAJ et ALT sur lesquelles l'utilisateur a appuyé simultanément.
        public Keys m_KeyData { get; set; }
        //
        // Résumé :
        //     Obtient les indicateurs de touches de modification d'un événement System.Windows.Forms.Control.KeyDown
        //     ou System.Windows.Forms.Control.KeyUp. Les indicateurs indiquent la combinaison
        //     de touches CTRL, MAJ et ALT activée.
        //
        // Retourne :
        //     Une valeur System.Windows.Forms.Keys représentant un ou plusieurs indicateurs
        //     de touches de modification.
        public Keys m_Modifiers { get; set; }
        //
        // Résumé :
        //     Obtient une valeur indiquant si la touche MAJ a été activée.
        //
        // Retourne :
        //     true si la touche MAJ était activée ; sinon, false.
        public virtual bool m_Shift { get; set; }
        //
        // Résumé :
        //     Obtient ou définit une valeur indiquant si l'événement de touche doit être transmis
        //     au contrôle sous-jacent.
        //
        // Retourne :
        //     true si l'événement de touche ne doit pas être transmis au contrôle ; sinon,
        //     false.
        public bool m_SuppressKeyPress { get; set; }
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