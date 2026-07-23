# Navian XR Engineer Challenge - Matías Gayo

![MRI volumétrica + meshes de segmentación alineados](docs/images/mri_plus_meshes.png)
---

## Índice

1. [Cómo abrir el proyecto](#1-cómo-abrir-el-proyecto)
2. [La escena en detalle](#2-la-escena-en-detalle)
3. [Uso de la solución propuesta](#3-uso-de-la-solución-propuesta)
4. [Limitaciones](#4-limitaciones)
5. [Mejoras a futuro](#5-mejoras-a-futuro)
6. [Licencia y créditos](#6-licencia-y-créditos)

---

## 1. Cómo abrir el proyecto

La solución del challenge utiliza la misma **Versión de Unity** que el proyecto base: **`6000.4.0f1`** (Unity 6), por lo que no hace falta realizar ninguna migración hacia otra versión. 
La solución se puede correr directamente desde Unity, utilizando el "Play Mode"

---

## 2. La escena en detalle

Al entrar a la escena del desafío vamos a ver el escenario principal otrogado por navian, el cual consiste del MRI junto con los modelos de los distintos componentes (piel, materia blanca, materia gris y venas). Dichos componentes tuvieron cambios en su material para que puedan distinguirse de forma más sencilla a la hora de ejecutar el ejercicio. Se realizaron pequeños cambios en la interfaz original del challenge, principalmente para informar por el cambio de algunos controles. Además se agregaron dos interfaces nuevas las cuales se utilizan para interactuar con la escena

---

## 3. Uso de la solución propuesta

### Funcionalidad principal

La idea de la solución fue crear una herramienta educativa, la cual le permita al usuario investigar un cerebro humano mientras que aprende sobre las partes que lo componen. Dentro de la escena podemos ver una UI simple con la cual vamos a manejar los tres "ejes de corte" que nos van a permitir ver el interior del modelo otorgado. Una vez accedamos a la sección que nos interese, podemos clickear en el objeto para que nos de una breve descripción de que estamos viendo. 

### Como se realizó

Se utilizó el sistema de cortes de UnityVolumeRendering para permitir que el usuario pueda ver el interior del modelo. Debido a que no fue posible segmentar el objeto que se genera con el MRI, se configuraron las shaders de los objetos 3D para que imiten el corte que se realiza en el VolumeRenderedObject. Se crearon tres objetos de corte, uno por cada eje, y se asociaron a sliders en una UI para que el usuario pueda ir modificando la visualización del modelo en tiempo real. 

## 4. Limitaciones

- **Cambios en el sistema de UI de Unity:** Debido a algunos problemas técnicos no pude utilizar los componentes de GUI de Unity, lo que hizo que necesite realizar todo con UI Document, la cual no es una herramienta compleja pero nunca tuve la necesidad de utilizarla, por lo que tuve demoras en la realización del challenge al tener que investigar un poco el uso de esta herramienta
- **Tiempo:** Debido a que lo realizado fue un desafío para una entrevista, se entiende el motivo por el cual se otorga una semana para realizarlo, sin embargo, en el caso de que se decida continuar con el proyecto, muchas de las mejoras propuestas en la próxima sección pueden ser implementadas facilmente
- **Colliders:** El uso de Mesh Colliders para identificar a los objetos llevó a un problema, debido a las formas que tienen los objetos 3D algunos Mesh Colliders no se registraban correctamente. Esto ocurre principalmente al querer interactuar con las venas, las cuales suelen quedar superpuestas por la materia gris

## 5. Mejoras a futuro

- **Mayor segmentación de los modelos y mejor descripción:** Con el uso de varios modelos distintos se puede generar un simulador más complejo que proporcione una versión más completa del cerebro que le proporcione más información al usuario
- **Mejoras de UI:** Se utilizó una UI muy básica para poder completar el challenge, el fondo utilizado fue un sprite de muestra que se encuentra en el proyecto y las interfaces creadas no coinciden visualmente con la interfaz proporcionada por Navian para el proyecto. Lo ideal si se busca mejorar el proyecto sería definir un estilo para este y adaptar todas las interfaces a dicho estilo
- **Mejoras de UX:** Hay dos mejoras que tuve en consideración para mejorar la experiencia del usuario:
  1. **Cambios en la interacción con los cortes:** Al cambiar los sliders de la UI con un objeto arrastrable dentro de la escena podría facilitarle al usuario el poder realizar el corte que desea en el modelo, otorgandole una herramienta más precisa. Tambén se puede implementar un selector de cortes que le permita al usuario seleccionar cuantas herramientas de corte quiere utilizar. Ahora mismo siempre estan activas las tres, lo cual puede sobrecargar al usuario de información que no necesita si quiere realizar cortes más simples
  2. **Cambios en la interacción con los objetos:** Actualmente puede ser poco intuitivo con que objeto estamos interactuando, debido a que no hay ningún indicador visual. Esto se puede solucionar haciendo que el objeto seleccionado haga algo cuando el mouse flote por encima de este (puede ser brillar, cambiar de color, generar un movimiento estilo "latido", etc). Esto permite que el usuario tenga una forma más intuitiva de saber que esta seleccionando
  3. **Evolución dinámica de los modelos:** Con las herramientas adecuadas se podría generar una segmentación del modelo 3D generado por el MRI y generar los demás modelos en tiempo real, lo cual nos permitiría poder darle un valor mayor al uso del **UnityVolumeRendering**
- **Cambio del sistema de interacción:** Como se menciona en la documentación del repositorio original del challenge, el proyecto utiliza el Unity Input Manager. El cambio al uso del Input System nos proporciona con una herramienta más compleja, lo cual permite un desarrollo más detallado a la hora de generar interacciones, lo cual es recomendable, especialmente si el proyecto busca en un futuro migrar a VR/AR 
  
---

## 6. Licencia y créditos

- **Código propio del desafío** (escena, `Assets/NavianChallenge/`, esta documentación):
  **MIT** © Navian — ver [`LICENSE`](LICENSE).
- **Librerías de terceros** (mantienen su propia licencia): UnityVolumeRendering (MIT),
  Nifti.NET (MIT), openDicom (LGPL). Detalle en [`THIRD-PARTY-NOTICES.md`](THIRD-PARTY-NOTICES.md).
- **Dataset:** la MRI IXI025 y los meshes derivados de ella están bajo **CC BY-SA 3.0**,
  con crédito al proyecto [IXI](https://brain-development.org/ixi-dataset/). Si redistribuís
  la data o trabajos derivados, mantené la atribución y la licencia.
- **Uso del repositorio:** En el caso que sea solicitado por los miembros de Navian, este repositorio será eliminado una vez se considere concluido el challenge
