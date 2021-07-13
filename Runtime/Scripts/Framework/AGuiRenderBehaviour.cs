using HexUN.Behaviour;
using HexUN.Utilities;

using System.Collections;

using UnityEngine;

namespace HexUN.Sub.UIUX.Framework
{
    /// <summary>
    /// <para>Provided a mechanism by which gui data is rendered.</para>
    /// 
    /// <para> All variables that will cause a visual change need to be registered 
    /// as OnChangeVariables to either the occasional or frequent stream. Anything 
    /// that is rendered often is put in frequent, and anything that 
    /// is rendered rarely is put in the occasional stream. Registering varaibles
    /// is done automatically when calling <see cref="GetOccasional{T}(ref OnChangeVariable{T})"/>
    /// or <see cref="SetOccasional{T}(ref OnChangeVariable{T}, T)"/> with frequent equivalents</para>
    /// 
    /// <para>When varaibles are set, the corresponding render function will be called, 
    /// implemented by the concrete class. <see cref="RenderOccasional"/></para>
    /// </summary>
    public abstract class AGuiRenderBehaviour : HexBehaviour
    {
        private Coroutine OccasionalCoroutine = null;
        private Coroutine FrequentCoroutine = null;

        /// <summary>
        /// Handle the logic required when a render occurs
        /// </summary>
        protected abstract void HandleOccasionalRender();

        /// <summary>
        /// Handle the logic required when a render occurs
        /// </summary>
        protected abstract void HandleFrequentRender();

        /// <summary>
        /// Perform a render on enable so that disabling and enabling elements
        /// doesn't cause a none render
        /// </summary>
        protected override void OnEnable()
        {
            base.OnEnable();
            RenderAll();
        }

        /// <summary>
        /// Initalization code for the ui element
        /// </summary>
        public virtual void Initialize()
        {
            RenderAll();
        }

        /// <summary>
        /// Renders the style elements of the Gui Element
        /// </summary>
        public void RenderOccasional()
        {
#if UNITY_EDITOR
            if (!Application.isPlaying)
            {
                HandleOccasionalRender();
                return;
            }
#endif
            if (OccasionalCoroutine == null && gameObject.activeInHierarchy) OccasionalCoroutine = StartCoroutine(OccasionalRoutine());
        }

        /// <summary>
        /// Used in OnValidate functions in Unity Editor to correctly provide validation behaviour
        /// when using OnChangeVariables
        /// </summary>
        public void SetOccasional<T>(ref OnChangeVariable<T> target, T value = default)
        {
            if (target == null) target = MakeOccasionalVar(value);
            else target.Value = value;
        }

        /// <summary>
        /// Used in OnValidate functions in Unity Editor to correctly provide validation behaviour
        /// when using OnChangeVariables
        /// </summary>
        public T GetOccasional<T>(ref OnChangeVariable<T> target)
        {
            if (target == null) target = MakeOccasionalVar<T>(default);
            return target.Value;
        }

        /// <summary>
        /// Renders the content elements of the GuiElement
        /// </summary>
        public void RenderFrequent()
        {
#if UNITY_EDITOR
            if (!Application.isPlaying)
            {
                HandleFrequentRender();
                return;
            }
#endif
            if (FrequentCoroutine == null) FrequentCoroutine = StartCoroutine(FrequentRoutine());
        }

        /// <summary>
        /// Used in OnValidate functions in Unity Editor to correctly provide validation behaviour
        /// when using OnChangeVariables
        /// </summary>
        public void SetFrequent<T>(ref OnChangeVariable<T> target, T value)
        {
            if (target == null) target = MakeFrequentVar(value);
            else target.Value = value;
        }

        /// <summary>
        /// Used in OnValidate functions in Unity Editor to correctly provide validation behaviour
        /// when using OnChangeVariables
        /// </summary>
        public T GetFrequent<T>(ref OnChangeVariable<T> target)
        {
            if (target == null) target = MakeFrequentVar<T>(default);
            return target.Value;
        }

        /// <summary>
        /// Call to force a render to happen this frame. A render will do work to
        /// update a views visuals. 
        /// </summary>
        public void RenderAll()
        {
            RenderOccasional();
            RenderFrequent();
        }

        /// <summary>
        /// Creates a variable that will automatically call RenderStyle when changed 
        /// </summary>
        public OnChangeVariable<T> MakeOccasionalVar<T>(T value = default)
        {
            OnChangeVariable<T> variable =  new OnChangeVariable<T>(RenderStyleOnChange);
            variable.Value = value;
            return variable;

            void RenderStyleOnChange(T var) => RenderOccasional();
        }

        /// <summary>
        /// Creates a variable that will automatically call RenderContent when changed 
        /// </summary>
        public OnChangeVariable<T> MakeFrequentVar<T>(T value = default)
        {
            OnChangeVariable<T> variable = new OnChangeVariable<T>(RenderContentOnChange);
            variable.Value = value;
            return variable;
            void RenderContentOnChange(T var) => RenderFrequent();
        }

        private IEnumerator OccasionalRoutine()
        {
            // ISSUE:
            // Based on https://docs.unity3d.com/Manual/ExecutionOrder.html we really want the render
            // to occur before GUI rendering so that all variables are set once. Waiting until end of frame
            // Makes updates delayed a bit. Might be bad UX
            yield return new WaitForEndOfFrame();
            HandleOccasionalRender();
            OccasionalCoroutine = null;
        }

        private IEnumerator FrequentRoutine()
        {
            // ISSUE:
            // Based on https://docs.unity3d.com/Manual/ExecutionOrder.html we really want the render
            // to occur before GUI rendering so that all variables are set once. Waiting until end of frame
            // Makes updates delayed a bit. Might be bad UX
            yield return new WaitForEndOfFrame();
            HandleFrequentRender();
            FrequentCoroutine = null;
        }
    }
}
