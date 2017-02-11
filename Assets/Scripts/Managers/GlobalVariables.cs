/// ==============================================================
/// © Mauricio Galvez ALL RIGHTS RESERVED
/// ==============================================================
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace Logic
{
    /// <summary>
    /// Manager used to manage global variables
    /// </summary>
    public class GlobalVariables : Singleton<GlobalVariables>
    {     
        /// <summary>
        /// Storage for global variables
        /// </summary>
        private Dictionary<string, object> m_VariableMap = null;

        /// <summary>
        /// Returns value of variable with given ID
        /// </summary>
        /// <param name="variableID">ID of global variable to obtain.</param>
        /// <returns></returns>
        public object GetValue(string variableID)
        {
            object value = null;
            if(m_VariableMap == null || m_VariableMap.Count ==0)
            {
                return null;
            }
            m_VariableMap.TryGetValue(variableID, out value);
            return value;
        }
    
        /// <summary>
        /// Register global variable into map
        /// </summary>
        public void RegisterVariable(GlobalVariable variable)
        {
            // Initialize map if null
            if(m_VariableMap == null)
            {
                m_VariableMap = new Dictionary<string, object>();
            }
            // add new global variable
            m_VariableMap.Add(variable.VariableID, variable.Value);
        }
        /// <summary>
        /// Unregister global variable from map
        /// </summary>
        /// <param name="variable">Global variable to unregister</param>
        public void UnregisterVariable(GlobalVariable variable)
        {
            if(m_VariableMap.Count != 0)
            {
                m_VariableMap.Remove(variable.VariableID);
            }
        }

    }
}
