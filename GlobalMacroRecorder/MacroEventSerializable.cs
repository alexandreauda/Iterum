using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GlobalMacroRecorder
{
    /// <summary>
    /// Series of events that can be recorded any played back
    /// </summary>
    [Serializable]
    public class MacroEventSerializable
    {
        #region ATTRIBUTES
        public MacroEventType MacroEventType;

        #region MouseEvent Attributes
        public MouseEventArgsSerializable MouseEventArgs;
        public MouseButtons m_button;
        public int m_clicks;
        public int m_x;
        public int m_y;
        public int m_delta;
        #endregion

        #region KeyEvent Attributes
        public KeysEventArgsSerializable KeyEventArgs;
        //
        // Résumé :
        //     Obtient une valeur indiquant si la touche ALT a été activée.
        //
        // Retourne :
        //     true si la touche ALT était activée ; sinon, false.
        public bool m_Alt;
        //
        // Résumé :
        //     Obtient une valeur indiquant si la touche CTRL a été activée.
        //
        // Retourne :
        //     true si la touche CTRL était activée ; sinon, false.
        public bool m_Control;
        //
        // Résumé :
        //     Obtient ou définit une valeur indiquant si l'événement a été géré.
        //
        // Retourne :
        //     true pour ignorer la gestion par défaut du contrôle ; sinon, false pour également
        //     passer l'événement au gestionnaire de contrôle par défaut.
        public bool m_Handled;
        //
        // Résumé :
        //     Obtient le code de clavier d'un événement System.Windows.Forms.Control.KeyDown
        //     ou System.Windows.Forms.Control.KeyUp.
        //
        // Retourne :
        //     Une valeur System.Windows.Forms.Keys représentant le code de touche pour l'événement.
        public Keys m_KeyCode;
        //
        // Résumé :
        //     Obtient la valeur de clavier d'un événement System.Windows.Forms.Control.KeyDown
        //     ou System.Windows.Forms.Control.KeyUp.
        //
        // Retourne :
        //     La représentation sous forme d'entier de la propriété System.Windows.Forms.KeyEventArgs.KeyCode.
        public int m_KeyValue;
        //
        // Résumé :
        //     Obtient les données de touches d'un événement System.Windows.Forms.Control.KeyDown
        //     ou System.Windows.Forms.Control.KeyUp.
        //
        // Retourne :
        //     System.Windows.Forms.Keys représentant le code de touche correspondant à la touche
        //     activée, associée à des indicateurs de touches de modification précisant les
        //     touches CTRL, MAJ et ALT sur lesquelles l'utilisateur a appuyé simultanément.
        public Keys m_KeyData;
        //
        // Résumé :
        //     Obtient les indicateurs de touches de modification d'un événement System.Windows.Forms.Control.KeyDown
        //     ou System.Windows.Forms.Control.KeyUp. Les indicateurs indiquent la combinaison
        //     de touches CTRL, MAJ et ALT activée.
        //
        // Retourne :
        //     Une valeur System.Windows.Forms.Keys représentant un ou plusieurs indicateurs
        //     de touches de modification.
        public Keys m_Modifiers;
        //
        // Résumé :
        //     Obtient une valeur indiquant si la touche MAJ a été activée.
        //
        // Retourne :
        //     true si la touche MAJ était activée ; sinon, false.
        public bool m_Shift;
        //
        // Résumé :
        //     Obtient ou définit une valeur indiquant si l'événement de touche doit être transmis
        //     au contrôle sous-jacent.
        //
        // Retourne :
        //     true si l'événement de touche ne doit pas être transmis au contrôle ; sinon,
        //     false.
        public bool m_SuppressKeyPress;
        #endregion

        public int TimeSinceLastEvent;
        #endregion

        public MacroEventSerializable() { }

        public MacroEventSerializable(MacroEventType macroEventType, MouseEventArgsSerializable eventArgs, int timeSinceLastEvent)
        {

            MacroEventType = macroEventType;
            MouseEventArgs = eventArgs;
            m_button = MouseEventArgs.getm_button();
            m_clicks = MouseEventArgs.getm_clicks();
            m_x = MouseEventArgs.getm_x();
            m_y = MouseEventArgs.getm_y();
            m_delta = MouseEventArgs.getm_delta();
            TimeSinceLastEvent = timeSinceLastEvent;

        }

        public MacroEventSerializable(MacroEventType macroEventType, KeysEventArgsSerializable eventArgs, int timeSinceLastEvent)
        {

            MacroEventType = macroEventType;
            KeyEventArgs = eventArgs;
            m_Alt = eventArgs.getm_Alt();
            m_Control = eventArgs.getm_Control();
            m_Handled = eventArgs.getm_Handled();
            m_KeyCode = eventArgs.getm_KeyCode();
            m_KeyValue = eventArgs.getm_KeyValue();
            m_KeyData = eventArgs.getm_KeyData();
            m_Modifiers = eventArgs.getm_Modifiers();
            m_Shift = eventArgs.getm_Shift();
            m_SuppressKeyPress = eventArgs.getm_SuppressKeyPress();
            TimeSinceLastEvent = timeSinceLastEvent;

        }

    }
}
