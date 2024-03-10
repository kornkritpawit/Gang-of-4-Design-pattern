using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace composite_pattern
{
    public class GroupComposite : Component
    {
        private List<Component> _components;
        public GroupComposite() {
            _components = new List<Component>();
        }

        public void Add(Component obj) {
            _components.Add(obj);
        }

        public void Move()
        {
            foreach (var component in _components)
            {
                component.Move();
            }
        }

        public void Render() {
            foreach (var component in _components)
            {
                component.Render();
            }
        }
    }
}