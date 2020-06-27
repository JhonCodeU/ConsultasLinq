using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tallerLinq
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Alumno> listaAlumnos = new List<Alumno>()
            {
                new Alumno("Eva",20,6.0,1,1,100),
                new Alumno("Ana" ,22,7.0,1,1,100),
                new Alumno("Rosa" ,22,4.0,1,15,100),
                new Alumno("Ot",20,3.0,1,2,101),
                new Alumno("Iu" ,30,6.8,2,3,101),
                new Alumno("Pep" ,32,6.9,3,3,101),
                new Alumno("Laia" ,30,2.3,4,4,101),
                new Alumno("Quim" ,32,1.7,4,4,101),
                new Alumno("Raul",20,6.0,5,5,102),
                new Alumno("valeria" ,25,7.0,6,6,103),//10 estudiantes
                new Alumno("valentina" ,24,4.0,7,7,104),
                new Alumno("katherine",22,3.0,8,8,105),
                new Alumno("julian" ,30,6.8,9,9,106),
                new Alumno("John" ,22,5.9,10,10,107),
                new Alumno("layla" ,27,2.3,11,11,108),
                new Alumno("Lesley" ,28,1.7,12,12,109),
                new Alumno("Melisa" ,29,6.8,13,12,109),
                new Alumno("Juan" ,36,5.9,14,13,110),
                new Alumno("Fernando" ,39,2.3,15,1,100),
                new Alumno("rafael" ,48, 7.2,14,14,110),//20 estudiantes
                new Alumno("bertha" ,36,7.0,2,15,104),
                new Alumno("erika",29,5.5,2,16,108),
                new Alumno("alberto" ,46,3.6,4,16,109),
                new Alumno("Jorge eduardo" ,39,7.1,4,16,105),
                new Alumno("rafaela" ,27,2.3,1,1,107),
                new Alumno("maria jose" ,31,3.8,2,1,100),
                new Alumno("Fabio" ,29,6.8,2,2,101),
                new Alumno("nick" ,36,5.9,2,3,103),
                new Alumno("juan esteban" ,39,2.3,2,4,101),
                new Alumno("nicolas" ,40,8.3,2,4,104),//30 estudiantes
                new Alumno("Diego",40,8.3,2,1,105),
                new Alumno("Margari",18,6.0,2,3,105),
                new Alumno("rafaela Nieto" ,27,2.3,1,1,107)

            };

            List<string> lstOrdenadosSoloNombres = (from d in listaAlumnos
                                                    orderby d.Nombre.Length descending
                                                    select (d.Edad + " Nombre: " + d.Nombre)).ToList();



            List<Alumno> datos = (from d in listaAlumnos
                                  orderby d.Nombre
                                  select (d)).ToList();


            var queryLongitud = from a in listaAlumnos
                                group a by a.Nombre.Length into g
                                orderby g.Key descending
                                select new
                                {
                                    Nombre = g.Key,
                                    Edad = g.Key,
                                    Alumnos = g.Take(4)
                                };

            var query = from a in listaAlumnos
                        group a by a.Nota into g
                        orderby g.Key descending
                        select new
                        {
                            Nota = g.Key,
                            Alumnos = g.Take(4)
                        };

            var queryEdad = from a in listaAlumnos
                            group a by a.Edad into g
                            orderby g.Key descending
                            select new
                            {
                                Edad = g.Key,
                                Alumnos = g.Take(4)
                            };

            //1. Alumnos que han aprobado mayores de 30 años.
            /*foreach (var dato in datos)
            {
                //Console.WriteLine(dato.Edad);
    
                if (dato.Nota > 6)
                {
                    if (dato.Edad > 30)
                    {
                        Console.WriteLine(dato);
                    }
                }
            }
            //2. Agrupar por Aprobado/Suspendido y mostrar la lista
            foreach (var dato in datos)
            {
                //Listar por aprobados
                if (dato.Nota >= 6)
                {
                    Console.WriteLine("Aprobado:    "+dato);
                }
            }
            //Listar por aprobados suspendidos
            foreach (var dato in datos)
            {
                if (dato.Nota < 6)
                {
                    Console.WriteLine("Suspendido:  "+dato);
                }
            }
            //3.Agrupar por la longitud del nombre ordenado de mayor a menor
            foreach (var nombre in lstOrdenadosSoloNombres)
            {
                    Console.WriteLine("Edad "+nombre);
            }
            
            //4. Agrupar por la longitud del nombre y mostrar aquellos grupos cuya suma de edades
            //es mayor de 60

            var sumaEdadGrupo = 0;
            
            foreach (var item in queryLongitud)
            {
                sumaEdadGrupo = 0;
                //Console.WriteLine("Edad: "+ item.Edad);
                //Console.WriteLine("Numero Estu: "+ item.Alumnos.Count());

                foreach (var alumno in item.Alumnos)
                {
                        sumaEdadGrupo = sumaEdadGrupo + alumno.Edad;

                    if (sumaEdadGrupo > 60)
                    {
                        Console.WriteLine("Alumnos: {0}", alumno.Nombre);
                    }
                    
                }
                if (sumaEdadGrupo>60)
                {
                    Console.WriteLine("Suma edades del grupo: " + sumaEdadGrupo+" años");
                    Console.WriteLine("");
                }
            }
            //5. Cuantos almunos hay.
            var contador = 0;
            foreach (var dato in datos)
            {
                contador = datos.Count();
            }
            Console.WriteLine("Hay "+contador+" estudiantes");
            
            //6. Agrupar los alumnos por notas mostrar cuantos de cada grupo y en un sub menu mostras la
            //lista de ellos
            
            foreach (var item in query)
            {
                Console.WriteLine("Nota {0}", item.Nota);
                Console.WriteLine(item.Alumnos.Count());

                foreach (var alumno in item.Alumnos)
                {
                    Console.WriteLine("Alumnos: {0}", alumno.Nombre);
                }
            }
            //7Agrupas los alumnos por Edad cuantos de cada grupo y en un sub menu mostras la lista de ellos
            foreach (var item in queryEdad)
            {
                Console.WriteLine("Edad {0}", item.Edad);
                Console.WriteLine("Hay "+ item.Alumnos.Count()+" Alumno en este grupo");

                foreach (var alumno in item.Alumnos)
                {
                    Console.WriteLine("Alumnos: {0}", alumno.Nombre);
                }
            }*/

            List<Asignatura> listaAsignatura = new List<Asignatura>()
            {
                new Asignatura("Matematicas","14 semanas",4,1),
                new Asignatura("Fisica","8 semanas",3,2),
                new Asignatura("Programacion","15 semanas",4,3),
                new Asignatura("Sociales","6 semanas",2,4),
                new Asignatura("Ingles","14 semanas",3,5),
                new Asignatura("Redes","14 semanas",4,6),
                new Asignatura("Seguridad","16 semanas",4,7),
                new Asignatura("Estructuras","14 semanas",4,8),
                new Asignatura("Bases de datos","14 semanas",4,9),
                new Asignatura("Calculo I","14 semanas",3,10),//10
                new Asignatura("Calculo II","14 semanas",3,11),
                new Asignatura("Calculo III","14 semanas",3,12),
                new Asignatura("Estadistica","14 semanas",3,13),
                new Asignatura("web I","14 semanas",3,14),
                new Asignatura("web II","14 semanas",3,15),//15
                new Asignatura("Textox y discursos","5 semanas",1,16),
                new Asignatura("laboratorio de fisica I","5 semanas",1,2)
            };

            // lo que hace esto es ordenar por nombre y traer los dos primeros valores
            // take es como un limitador 
            List<string> lstOrdenadoMateria = (from d in listaAsignatura
                                               orderby d.NombreA
                                               select d.NombreYCreditos).Skip(4).Take(2).ToList();
            

            List<Asignatura> concatenarConUnion = new List<Asignatura>()
            {
                new Asignatura("Vias","12 semanas",3,18),
                new Asignatura("Medicina forence","14 semanas",3,17),
                new Asignatura("web I","14 semanas",3,19)
            };

            var queryRepetidos = from repetidos in listaAsignatura
                                 join repetidos1 in concatenarConUnion
                                 on repetidos.NombreYCreditos equals repetidos1.NombreYCreditos
                                 select repetidos.NombreYCreditos;

            var querysumaMaterias = from d in listaAsignatura
                                    group d by d.Creditos into creditosGroup
                                    select new
                                    {
                                        Creditos = creditosGroup.Key,
                                        totalCreditos = creditosGroup.Max(x => x.Creditos),
                                        Materias = creditosGroup.Count()
                                    };

            var queryMin = (from d in listaAsignatura
                            orderby d.NombreA
                            select d.Creditos).Min();

            //Console.WriteLine(queryMin);


            List <String> lstaUnion = (
                                        from a in
                                        (from d in listaAsignatura
                                          select d)
                                          .Union(
                                                from d in concatenarConUnion
                                                select d
                                            )
                                          orderby a.NombreA
                                        select a.NombreYCreditos
                                          )
                                          .ToList();

            List<Asignatura> busqueda = (from d in listaAsignatura
                                          where d.Creditos.Equals(4)
                                          select d).ToList();

            List<Profesor> listaProfesores = new List<Profesor>()
            {
                new Profesor("Julio jaramillo","politico",43,4),
                new Profesor("Daniela parra","Matematica pura",32,1),
                new Profesor("Stefania mendoza","Matematica pura",30,1),
                new Profesor("Daniel ruiz","Ingeniero Fisico",28,2),
                new Profesor("Hector calvis","Ingeniero Fisico",44,2),
                new Profesor("Jaime rendon","Ingeniero sistemas",25,8),
                new Profesor("oscar alfonso","Ingeniero informatico",36,9),
                new Profesor("Jhonny ariztizabal","Ingeniero de software",38,2),
                new Profesor("luisa fernanda","Matematica pura",28,1),
                new Profesor("diego velez","Ingeniero sistemas",26,6),
                new Profesor("brandon smith","Licenciado en literatura",39,16),
                new Profesor("Jose smith","licenciado en lenguas",35,5),
                new Profesor("Erika emilia","Licenciada en lenguas",39,5),
                new Profesor("Fernando mendoza","Ingeniero sistemas",25,15),
                new Profesor("Yuli orozco","Medica",25,17),//15
                new Profesor("Daniela ceballos","Medica",30,17)
            };

            var queryProfe = (from d in listaProfesores
                              orderby d.Nombre
                              where d.Profeccion.Equals("Ingeniero sistemas")
                              select d).ToList();

            var asignaturaP = from d in listaProfesores
                              join c in listaAsignatura on d.idAsignaturaP equals c.idAsignatura
                              orderby d.idAsignaturaP
                              group d by new { c.idAsignatura, c.NombreA, d.Nombre } into grupo
                              select grupo;

            var rangoEdadP = (from d in listaProfesores
                              orderby d.Nombre
                              where (d.Edad > 25 && d.Edad < 40)
                              select d).ToList();

            var MateriasPro = from d in listaProfesores
                              join c in listaAsignatura on d.idAsignaturaP equals c.idAsignatura
                              orderby d.idAsignaturaP
                              where c.Duracion.Equals("14 semanas")
                              group d by new { c.idAsignatura, c.NombreA, c.Duracion, d.Nombre } into grupo
                              select grupo;

            var obtenerNombresIguales = (from d in listaProfesores
                                          orderby d.Nombre
                                          where d.Nombre.Contains("Daniela")
                                          select d).ToList();

            var ingenierosYMedicos = (from d in listaProfesores
                                         orderby d.Profeccion
                                      where d.Profeccion.Contains("Ingeniero") && d.Edad > 40
                                      select d).ToList();

            var userFound = listaProfesores.Where(u => u.Edad > 18).ToList();

            Func<Profesor, bool> where = new Func<Profesor, bool>((profesor) =>
            {
                return profesor.Edad > 18;
            });
            var groupEdades = listaProfesores.ToLookup(u => "\n"+u.Profeccion).OrderByDescending(o => o.Key);

            //GruopBy vs TolookUp
            /*
            foreach (var edad in groupEdades)
            {
                Console.WriteLine(edad.Key);
                var profesoresEdad = edad.ToList();

                foreach (var pro in profesoresEdad)
                {
                    Console.WriteLine(pro.Nombre);
                }
            }*/
            /*
            List<Profesor> filtro = new List<Profesor>();
            foreach(var profesor in listaProfesores)
            {
                if (where(profesor))
                {
                    filtro.Add(profesor);
                }
            }
            foreach (var i in filtro)
            {
                Console.WriteLine(i.Nombre);
            }

            
            foreach (var i in ingenierosYMedicos)
            {
                Console.WriteLine(": "+i.EdadYNombre);
            }*/

            /*
            foreach (var grupo in MateriasPro)
            {
                Console.WriteLine(" ID: " + grupo.Key.idAsignatura+" Materia: " 
                    + grupo.Key.NombreA + "duracion: "+grupo.Key.Duracion+ "Profesor: "+grupo.Key.Nombre);
            }
            /*
            foreach (var profeccion in queryProfe)
            {
                if(profeccion.Edad > 24)
                {
                    Console.WriteLine(profeccion.Nombre + " - " + profeccion.Profeccion);
                }
            }*/

            List<Programa> listaProgramas = new List<Programa>()
            {
                new Programa("Ingenieria en sistemas","10 semestres",180,1),
                new Programa("Ingenieria en informatica","10 semestres",179,2),
                new Programa("Ingenieria en fisica","10 semestres",160,3),
                new Programa("Matematica pura","10 semestres",175,4),
                new Programa("Ingenieria de alimentos","10 semestres",165,5),
                new Programa("Ingenieria electronica","10 semestres",178,6),
                new Programa("Ingenieria civil","10 semestres",180,7),
                new Programa("Tecnico en sistemas","4 semestres",80,8),
                new Programa("Salud ocupacional","4 semestres",75,9),
                new Programa("Medicina","10 semestres",180,10),
                new Programa("Sociales","9 semestres",152,11),
                new Programa("Lenguas modernas","10 semestres",180,12),
                new Programa("enfermeria","8 semestres",125,13),
                new Programa("Tecnologia en sistemas","6 semestres",100,14),
                new Programa("ingenieria agropecuaria","10 semestres",170,15),
                new Programa("ingenieria agropecuaria","10 semestres",165,16)
            };

            var AlumnoPrograma = from d in listaAlumnos
                                 join p in listaProgramas
                                 on d.Idprograma equals p.Idprograma
                                 select (d.Nombre+" - "+p.Nombre);

            var agruparUniverdadAlumno = from d in listaAlumnos
                                         join c in listaProgramas on d.Idprograma equals c.Idprograma
                                         orderby d.Idprograma
                                         group d by new { c.Nombre, d.EdadYNombreAlumno } into grupo
                                         select grupo;

            var nombreOrdenadorProgramas = (from programa in listaProgramas
                                            orderby programa.Idprograma
                                            select programa.TotalCreditos).ToArray();


            bool all = listaAlumnos.All(u => u.Edad > 17 && u.Edad < 50);/*
            if (all)
            {
                Console.WriteLine("Todos cumplen");
            }
            else
            {
                Console.WriteLine("No cumplen la condicion");
            }

            var any = listaAlumnos.Any(e => e.Edad == 18);
            if (any)
            {
                Console.WriteLine("Existe por lo menos uno que tenga 18 anios");
            }*/

            var promedio = listaAlumnos.Average(e => e.Nota);
            //Console.WriteLine(promedio);

            var firProgramas = listaProgramas.First();
            var firstProgramas = listaProgramas.FirstOrDefault(e => e.Nombre == "ingenieria agropecuaria");
            var AlumnoDefault = listaAlumnos.FirstOrDefault(e => e.Edad == 10 && e.Nombre == "No tiene");


            var programasSelect = listaProgramas.Where(s => s.TotalCreditos > 150)
                      .Select(s => s)
                      .Where(st => st.Idprograma > 0)
                      .Select(s => s.Nombre);

            var programaGroup = from s in listaProgramas
                                          where s.Idprograma > 0
                                          group s by s.Duracion into sg
                                          orderby sg.Key
                                          select new { sg.Key, sg };

            /*
            foreach (var group in programaGroup)
            {
                Console.WriteLine("\n"+group.Key);

                group.sg.ToList().ForEach(st => Console.WriteLine(st.Nombre));
            }*/

            var studentsGroup = from stad in listaProgramas
                                join s in listaAlumnos
                                on stad.Idprograma equals s.Idprograma
                                    into sg
                                select new
                                {
                                    StandardName = stad.Nombre,
                                    Students = sg
                                };
            /*
            foreach (var group in studentsGroup)
            {
                Console.WriteLine(group.StandardName);

                group.Students.ToList().ForEach(st => Console.WriteLine(st.Nombre));
            }*/
            var studentsWithStandard = from stad in listaProgramas
                                       join s in listaAlumnos
                                       on stad.Idprograma equals s.Idprograma
                                       into sg
                                       from std_grp in sg
                                       orderby stad.Nombre, std_grp.Nombre
                                       select new
                                       {
                                           StudentName = std_grp.Nombre,
                                           StandardName = stad.Nombre
                                       };

            /*
            foreach (var group in studentsWithStandard)
            {
                Console.WriteLine("{0} Esta en {1}", group.StudentName, group.StandardName);
            }*/
            var nestedQueries = from s in listaAlumnos
                                where s.Edad > 18 && s.Idprograma ==
                                    (from std in listaProgramas
                                     where std.Nombre == "Ingenieria en sistemas"
                                     select std.Idprograma).FirstOrDefault()
                                select s;

            //nestedQueries.ToList().ForEach(s => Console.WriteLine(s.Nombre));
            /*
            foreach (var i in nombreOrdenadorProgramas)
            {
                Console.WriteLine(i.Equals(180));
            }*/

            List<universidad> listaUniversidades = new List<universidad>()
            {
                new universidad("Universidad de caldas","Manizales",30,1,100),
                new universidad("Universidad de América","Bogota",25,2,101),
                new universidad("Politécnico Grancolombiano","Bogota",20,3,101),
                new universidad("Universidad Nacional","Bogota",50,4,101),
                new universidad("Universidad del Atlántico","Barranquilla",30,5,102),
                new universidad("Universidad del Quindio","Quindio",19,6,103),
                new universidad("Universidad de Antioquia","Medellin",40,7,104),
                new universidad("Universidad de Córdoba","Monteria",30,8,105),
                new universidad("Universidad de Manizales","Manizales",25,9,100),
                new universidad("Universidad Antonio Nariño","Quibdó",25,10,106),
                new universidad("Universidad Mariana","Pasto",24,11,107),
                new universidad("Universidad del valle","Cali",35,12,108),
                new universidad("Universidad javeriana","Bogota",50,13,101),
                new universidad("Universidad bolivariana","palmira",50,14,109),
                new universidad("Universidad autonoma de manizales","Manizales",32,15,100),
                new universidad("Universidad de boyaca","boyaca",12,16,110)

            };

            var groupCity = from u in listaUniversidades
                            join s in listaAlumnos
                            on u.IdCiudad equals s.IdCiudad
                            into sg
                            from std_grp in sg
                            orderby u.Nombre, std_grp.Nombre
                            select new
                            {
                                StudentName = std_grp.Nombre,
                                StandardName = u.Ciudad
                            };

            var universidadCity = from s in listaUniversidades
                            group s by s.Ciudad into sg
                            orderby sg.Key
                            select new { sg.Key, sg };
            /*
            foreach (var group in universidadCity)
            {
                Console.WriteLine(group.Key);

                group.sg.ToList().ForEach(st => Console.WriteLine(st.Nombre));
            }*/
            //Console.WriteLine("Universidad de Caldas");

            var alumnosCity  = from s in listaAlumnos
                                where s.Nota > 6.0 && s.IdUniversidad ==
                                    (from std in listaUniversidades
                                    where std.IdUniversidad == s.IdUniversidad
                                    select std.IdUniversidad).FirstOrDefault()
                                select s;

            alumnosCity.ToList().ForEach(s => Console.WriteLine(s.Nombre));

            var group2 = from s in listaAlumnos
                         group s by s.Nombre.Contains("rafaela") into sg
                         orderby sg.Key
                         select new { sg.Key, sg };

            /*
            foreach (var group in group2)
            {
                Console.WriteLine("\n"+group.Key);

                group.sg.ToList().ForEach(st => Console.WriteLine(st.Nombre));
            }*/

            var JoinDeTresListas = from d in listaAlumnos
                                   join c in listaProgramas on d.Idprograma equals c.Idprograma
                                   join s in listaUniversidades on d.IdUniversidad equals s.IdUniversidad
                                   select new
                                   {
                                       I = s.Nombre,
                                       Programa = c.Nombre,
                                       Nombre = d.Nombre
                                       // other assignments
                                   };
            /*
            foreach (var i in JoinDeTresListas)
            {
                Console.WriteLine(i);
            }*/

            var whereJoinDeTresListas = from d in listaAlumnos
                                   join c in listaProgramas on d.Idprograma equals c.Idprograma
                                   join s in listaUniversidades on d.IdUniversidad equals s.IdUniversidad
                                   where d.IdUniversidad.Equals(1)
                                      select new
                                   {
                                       I = s.Nombre,
                                       Programa = c.Nombre,
                                       Nombre = d.Nombre
                                       // other assignments
                                   };
            /*
            foreach (var i in whereJoinDeTresListas)
            {
                Console.WriteLine(i);
            }*/
            var CJoinDeTresListas = from s in listaAsignatura
                                    join c in listaProfesores on s.idAsignatura equals c.idAsignaturaP
                                    where s.NombreA == ("laboratorio de fisica I")
                                    select new { 
                                        A = s.NombreA,
                                        P = c.Nombre
                                    };
            /*
            foreach (var i in CJoinDeTresListas)
            {
                Console.WriteLine(i);
            }*/

            var UniversidadYEdadAlumnoGroup = from a in listaAlumnos
                                              join u in listaUniversidades on a.IdUniversidad equals u.IdUniversidad
                                              orderby a.Edad, u.Nombre
                                                 select new
                                                 {
                                                     U = u.Nombre,
                                                     E = a.Nombre,
                                                     edad = a.Edad,
                                                 };
            UniversidadYEdadAlumnoGroup.ToList().ForEach(s => Console.WriteLine
            ("Student Name: {0}, Age: {1}, StandardID: {2}", s.U, s.E, s.edad));

        }
    }
}
