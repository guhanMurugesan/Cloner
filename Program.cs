using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloner
{
    /*
     * Avoid icloneable interface
     * Problems icloneable causes are, 
     * 1. identifying deepclone or shallow clone is impossible
     * 2. down return type to the concrete type
     */
    class Program
    {
        static void Main(string[] args)
        {

            Project project = new Project(123,"iView");
            ScientificGamesEmployee company = new ScientificGamesEmployee(107300,"guhan",project);
            CloneObject(() => ScientificGamesEmployee.DeepCopy(company));
            Console.ReadKey();
        }

        static void CloneObject(Func<ScientificGamesEmployee> deepCopy) //delegate is used instead of icloneable because delegates just returns. Nothing more than that.
        {
            ScientificGamesEmployee clonedIntance = deepCopy();
            clonedIntance.Print();
        }
    }

    class ScientificGamesEmployee
    {
        private int empId;
        private string empName;
        private Project empProject;

        public ScientificGamesEmployee(int id,string name,Project project)
        {
            empId = id;
            empName = name;
            empProject = project;
        }


        public static ScientificGamesEmployee DeepCopy(ScientificGamesEmployee instance)
        {
            return new ScientificGamesEmployee(instance.empId, instance.empName, new Project(instance.empProject));
        }

        public static ScientificGamesEmployee ShallowCopy(ScientificGamesEmployee instance)
        {
            return new ScientificGamesEmployee(instance.empId, instance.empName, instance.empProject);
        }

        public void Print()
        {
            Console.WriteLine("Employee id:{0} name:{1}",this.empId,this.empName);
            this.empProject.print();
        }

    }

    class Project
    {
        private int pId;
        private string pName;
     
        public Project(int id,string name)
        {
            pId = id;
            pName = name;
        }

        public Project(Project p):this(p.pId,p.pName)
        {
        }

        public void print()
        {
            Console.WriteLine("Project id:{0} name:{1}", this.pId, this.pName);
        }
    }
}
