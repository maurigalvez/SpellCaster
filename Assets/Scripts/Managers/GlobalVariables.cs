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
        /// Add variables to use in map.
        /// </summary>
        /*private IEnumerator Initialize()
        {
            // check if any variables were assinged
            if (m_Variables.Length > 0)
            {
                m_VariableMap = new Dictionary<string, object>();
                for(int variableIndex = 0; variableIndex < m_Variables.Length; variableIndex++)
                {
                    m_VariableMap.Add(m_Variables[variableIndex].VariableID, m_Variables[variableIndex].Value);
                }
            }
            yield return null;
        }*/

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

    }
}
