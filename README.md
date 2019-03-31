# Práctica Profesional - Diagnóstico 2019

**Profesor**: Gastón Weingand

**Build Status:** [![Build Status](https://dev.azure.com/victorgrycuk-facultad/PracticaProfesional-Diagnostico2019/_apis/build/status/VictorGrycuk.practica-profesional-diagnostico?branchName=master)](https://dev.azure.com/victorgrycuk-facultad/PracticaProfesional-Diagnostico2019/_build/latest?definitionId=1&branchName=master)

Follow the build process [here](https://dev.azure.com/victorgrycuk-facultad/PracticaProfesional-Diagnostico2019/_build?definitionId=1).

---

## Vista General

| Task                                 | Status                                                       |
| ------------------------------------ | ------------------------------------------------------------ |
| Find even numbers in array           | [Done](https://github.com/VictorGrycuk/practica-profesional-diagnostico/blob/master/Diagnostico2019/Exercises/EvenNumbers.cs) :heavy_check_mark: |
| Bubble Sort                          | [Done](https://github.com/VictorGrycuk/practica-profesional-diagnostico/blob/master/Diagnostico2019/Exercises/BubbleSort.cs) :heavy_check_mark: |
| Get every Monday between given dates | [Done](https://github.com/VictorGrycuk/practica-profesional-diagnostico/blob/master/Diagnostico2019/Exercises/Dates.cs) :heavy_check_mark: |
| Generate Fibonacci Sequence          | [Done](https://github.com/VictorGrycuk/practica-profesional-diagnostico/blob/master/Diagnostico2019/Exercises/Fibonnacci.cs) :heavy_check_mark: |
| Compare Images                       | [Done](https://github.com/VictorGrycuk/practica-profesional-diagnostico/blob/master/Diagnostico2019/Exercises/ImageValidation.cs) :heavy_check_mark: |
| Calculate Ohm's law                  | To Do :bookmark_tabs:                                        |
| Distance between two given points    | To Do :bookmark_tabs:                                        |
| Create a Hash algorithm              | To Do :bookmark_tabs:                                        |
| Jagged array                         | To Do :bookmark_tabs:                                        |
| Parabolic projectile                 | To Do :bookmark_tabs:                                        |

---

### Realizar los siguientes ejercicios de repaso-diagnóstico.

1. Dado el vector `{45, 23, 52, 68, 2, 98, 106, 107, 465, 23, 18}` decir **cuántos y cuáles son números pares**.

2. Realizar un **ordenamiento de burbuja** de Mayor a Menor del vector `{23, 1, 5, 2, 98, 14, 76, 98, 104, 3, 9}`.

3. A partir de la fecha actual informar qué fechas serán **lunes** hasta el año 2018.

4. Generar un vector de 20 posiciones con la sucesión de **Fibonacci**.

5. Dadas dos imágenes decir si son **iguales o diferentes**.

6. Realizar un programa que permita realizar los cálculos de la **ley de ohm**.

7. Realizar un programa que permita calcular la **distancia de dos puntos** (`x0, y0` e `x1, y1`) en un plano.

8. Genere su propio algoritmo de **Hash**.

9. Dada la **matriz escalonada**:

   ```c#
   int[][] jaggedArray = new int[][]
   {
       new int[] {1, 3, 5, 7, 9},
       new int[] {0,2,4,6},
       new int[] {11,22}
   }
   ```

   Generar un mecanismo para encontrar la posición del elemento entero 4 (O el que usted designe) dentro de la misma. El resultado de buscar 4 debería ser `[2, 3]`.

10. Realizar un programa que permita calcular altura máxima y alcance horizontal para un **tiro parabólico** dados los parámetros velocidad inicial y Ángulo de disparo.