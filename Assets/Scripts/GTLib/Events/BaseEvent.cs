using com.gt.entities;
namespace com.gt.events
{
    using System;
    using System.Collections;

    /// <summary>
    /// 
    /// </summary>
    public class BaseEvent
    {
        /// <summary>
        /// 
        /// </summary>
        protected IMPObject arguments;
        /// <summary>
        /// 
        /// </summary>
        protected object target;
        /// <summary>
        /// 
        /// </summary>
        protected string type;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        public BaseEvent(string type)
        {
            this.type = type;
            if (arguments == null)
            {
                arguments = MPObject.NewInstance();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="args"></param>
        public BaseEvent(string type, IMPObject args)
        {
            this.type = type;
            arguments = args;
            if (arguments == null)
            {
                arguments = MPObject.NewInstance();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public BaseEvent Clone()
        {
            return new BaseEvent(type, arguments);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return type + " [ " + (target == null ? "null" : target.ToString()) + "]";
        }

        /// <summary>
        /// 
        /// </summary>
        public IMPObject Params
        {
            get
            {
                return arguments;
            }
            set
            {
                arguments = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public object Target
        {
            get
            {
                return target;
            }
            set
            {
                target = value;
            }
        }

        /// <summary>
        /// The type get/set
        /// </summary>
        public string Type
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
            }
        }
    }
}

