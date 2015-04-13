using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DoFactory.Framework.ViewState
{
    /// <summary>
    /// GlobalViewStateSingleton maintains a list of viewstates in a 
    /// globally accessible hashtable. This is a Singleton helper class to the 
    /// ViewStateProviderGlobal class.
    /// 
    /// Gof Design Pattern: Singleton.
    /// </summary>
    /// <remarks>
    /// The Singleton Design Pattern ensures that just one instance (the Singleton) 
    /// holds a reference to a list of all viewstate providers declared in the 
    /// configuration file (web.config).
    /// </remarks>
    public class GlobalViewStateSingleton
    {
        // Hashtable that holds all viewstates
        private Hashtable _viewStates = new Hashtable();

        #region The Singleton definition

        // This single instance of this class
        private static readonly GlobalViewStateSingleton _instance = new GlobalViewStateSingleton();

        /// <summary>
        /// Private constructor for GlobalViewStateSingleton.
        /// Prevents others from instantiating additional instances.
        /// </summary>
        private GlobalViewStateSingleton()
        {
        }

        /// <summary>
        /// Gets the one instance of the GlobalViewStateSingleton class
        /// </summary>
        public static GlobalViewStateSingleton Instance
        {
            get { return _instance; }
        }

        #endregion

        /// <summary>
        /// Gets a list of ViewStates.
        /// </summary>
        public Hashtable ViewStates
        {
            get { return _viewStates; }
        }
    }
}
