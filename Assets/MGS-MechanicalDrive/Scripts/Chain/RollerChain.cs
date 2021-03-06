/*************************************************************************
 *  Copyright (C), 2017-2018, Mogoson Tech. Co., Ltd.
 *------------------------------------------------------------------------
 *  File         :  RollerChain.cs
 *  Description  :  Define RollerChain component.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  6/21/2017
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace Developer.MechanicalDrive
{
    [AddComponentMenu("Developer/MechanicalDrive/RollerChain")]
    public class RollerChain : Chain
    {
        #region Property and Field
        /// <summary>
        /// Roller prefab of chain.
        /// </summary>
        public GameObject rollerPrefab;
        #endregion

        #region Public Method
        /// <summary>
        /// Create chain nodes.
        /// </summary>
        public override void CreateNodes()
        {
            nodes = new Node[count];
            bool replace = false;
            for (int i = 0; i < count; i++)
            {
                //Alternate prefab.
                var prefab = nodePrefab;
                if (replace)
                    prefab = rollerPrefab;

                //Create node.
                var nodeClone = Instantiate(prefab);
                nodeClone.transform.SetParent(nodeRoot);

                //Tow node.
                TowNodeBaseOnCurve(nodeClone.transform, i * space);

                //Set node ID.
                nodes[i] = nodeClone.GetComponent<Node>();
                nodes[i].ID = i;

                //Alternate replace.
                replace = !replace;
            }
        }
        #endregion
    }
}