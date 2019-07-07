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
    class MouseEventArgsSerializable
    {
        #region ATTRIBUTES
        /****************** ATTRIBUTES ******************/
        private MouseButtons m_button;
        private int m_clicks;
        private int m_x;
        private int m_y;
        private int m_delta;
        private Point m_location;
        #endregion


        #region CONSTRUCTOR
        /****************** CONSTRUCTOR ******************/
        // Constructor of MouseEventArgsSerializable
        public MouseEventArgsSerializable(MouseButtons button, int clicks, int x, int y, int delta)
        {
            m_button = button;
            m_clicks = clicks;
            m_x = x;
            m_y = y;
            m_delta = delta;
        }
        #endregion


        #region GETTER
        /****************** GETTER ******************/
        //Get the attribute m_button
        public MouseButtons getm_button()
        {
            return m_button;//Return the attribute m_button
        }

        //Get the attribute m_clicks
        public int getm_clicks()
        {
            return m_clicks;//Return the attribute m_clicks
        }

        //Get the attribute m_x
        public int getm_x()
        {
            return m_x;//Return the attribute m_x
        }

        //Get the attribute m_y
        public int getm_y()
        {
            return m_y;//Return the attribute m_y
        }

        //Get the attribute m_delta
        public int getm_delta()
        {
            return m_delta;//Return the attribute m_delta
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