using HexUN.Behaviour;
using HexUN.Utilities;

using System.Collections;

using UnityEngine;

namespace HexUN.Sub.UIUX.Framework
{
    /// <summary>
    /// Provided a mechanism by which gui data is rendered
    /// </summary>
    public abstract class GuiRenderBehaviour : HexBehaviour
    {
        private Coroutine StyleCoroutine = null;
        private Coroutine ContentCoroutine = null;

        /// <summary>
        /// Handle the logic required when a render occurs
        /// </summary>
        protected abstract void HandleStyleRender();

        /// <summary>
        /// Handle the logic required when a render occurs
        /// </summary>
        protected abstract void HandleContentRender();


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
        public void RenderStyle()
        {
#if UNITY_EDITOR
            if (!Application.isPlaying)
            {
                HandleStyleRender();
                return;
            }
#endif
            if (StyleCoroutine == null && gameObject.activeInHierarchy) StyleCoroutine = StartCoroutine(StyleRoutine());
        }

        /// <summary>
        /// Used in OnValidate functions in Unity Editor to correctly provide validation behaviour
        /// when using OnChangeVariables
        /// </summary>
        public void SetStyle<T>(ref OnChangeVariable<T> target, T value = default)
        {
            if (target == null) target = MakeStyleVar(value);
            else target.Value = value;
        }

        /// <summary>
        /// Used in OnValidate functions in Unity Editor to correctly provide validation behaviour
        /// when using OnChangeVariables
        /// </summary>
        public T GetStyle<T>(ref OnChangeVariable<T> target)
        {
            if (target == null) target = MakeStyleVar<T>(default);
            return target.Value;
        }

        /// <summary>
        /// Renders the content elements of the GuiElement
        /// </summary>
        public void RenderContent()
        {
#if UNITY_EDITOR
            if (!Application.isPlaying)
            {
                HandleContentRender();
                return;
            }
#endif
            if (ContentCoroutine == null) ContentCoroutine = StartCoroutine(ContentRoutine());
        }

        /// <summary>
        /// Used in OnValidate functions in Unity Editor to correctly provide validation behaviour
        /// when using OnChangeVariables
        /// </summary>
        public void SetContent<T>(ref OnChangeVariable<T> target, T value)
        {
            if (target == null) target = MakeContentVar(value);
            else target.Value = value;
        }

        /// <summary>
        /// Used in OnValidate functions in Unity Editor to correctly provide validation behaviour
        /// when using OnChangeVariables
        /// </summary>
        public T GetContent<T>(ref OnChangeVariable<T> target)
        {
            if (target == null) target = MakeContentVar<T>(default);
            return target.Value;
        }

        /// <summary>
        /// Call to force a render to happen this frame. A render will do work to
        /// update a views visuals. 
        /// </summary>
        public void RenderAll()
        {
            RenderStyle();
            RenderContent();
        }

        /// <summary>
        /// Creates a variable that will automatically call RenderStyle when changed 
        /// </summary>
        public OnChangeVariable<T> MakeStyleVar<T>(T value = default)
        {
            OnChangeVariable<T> variable =  new OnChangeVariable<T>(RenderStyleOnChange);
            variable.Value = value;
            return variable;

            void RenderStyleOnChange(T var) => RenderStyle();
        }

        /// <summary>
        /// Creates a variable that will automatically call RenderContent when changed 
        /// </summary>
        public OnChangeVariable<T> MakeContentVar<T>(T value = default)
        {
            OnChangeVariable<T> variable = new OnChangeVariable<T>(RenderContentOnChange);
            variable.Value = value;
            return variable;
            void RenderContentOnChange(T var) => RenderContent();
        }

        private IEnumerator StyleRoutine()
        {
            // ISSUE:
            // Based on https://docs.unity3d.com/Manual/ExecutionOrder.html we really want the render
            // to occur before GUI rendering so that all variables are set once. Waiting until end of frame
            // Makes updates delayed a bit. Might be bad UX
            yield return new WaitForEndOfFrame();
            HandleStyleRender();
            StyleCoroutine = null;
        }

        private IEnumerator ContentRoutine()
        {
            // ISSUE:
            // Based on https://docs.unity3d.com/Manual/ExecutionOrder.html we really want the render
            // to occur before GUI rendering so that all variables are set once. Waiting until end of frame
            // Makes updates delayed a bit. Might be bad UX
            yield return new WaitForEndOfFrame();
            HandleContentRender();
            ContentCoroutine = null;
        }
    }
}
