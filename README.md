<p align="left">
  <img src="./logo.jpg" alt="Image Campus" width="200"/>
</p>

# TP04_C1_BlancoRomero_RetroPong

### Itch.io
https://agustinlazaro.itch.io/

---

## Español

### Game details
Reinterpretación en Unity 2D del clásico Pong para dos jugadores locales,
enfocada en buenas prácticas de arquitectura,
desacoplamiento de configuraciones mediante ScriptableObjects y detección de colisiones basada en componentes.

### Cómo jugar
* **Jugador 1:** `W` / `S` (Arriba / Abajo) — `A` / `D` (Izquierda / Derecha)
* **Jugador 2:** `Flecha Arriba` / `Flecha Abajo` — `Flecha Izquierda` / `Flecha Derecha`

**Mecánicas principales:**
* **Objetivo:** Defender el arco propio y anotar en el campo rival logrando que la pelota cruce la línea de gol.
* **Aceleración progresiva:** Cada impacto de la pelota contra una paleta incrementa su velocidad, aumentando el dinamismo y la exigencia de los reflejos en peloteos largos.
* **Rebote dinámico:** Las paredes superior e inferior devuelven la pelota al campo con leves variaciones de ángulo para evitar trayectorias estáticas.
* **Power-Ups:** Desactivados. aun en proceso. solo aparece un gameobject de lado a lado para comprobar el feedback de recoleccion del objeto
### Opciones y Configuración (Settings)
El juego cuenta con un panel de ajustes respaldado por ScriptableObjects que permite personalizar la partida en tiempo real:

* **Velocidad de las paletas:** Sliders individuales para calibrar la velocidad de desplazamiento del Jugador 1 y Jugador 2 de forma independiente.
* **Personalización de color:** Selector visual para modificar el tono de cada paleta según la preferencia de los jugadores.
* **Reglas de juego:** Ajuste de parámetros globales del partido, elegir la cantidad de puntos a anotar o el tiempo para anotar.
  
> **Nota sobre el movimiento de la pelota:** La física y los ángulos de rebote actuales aún no son perfectos y presentan comportamientos a pulir (como trayectorias rasantes ocasionales o choques en bordes de paleta),
>  por lo que quedan pendientes de arreglo en futuras iteraciones.
>  ¡Cualquier feedback, sugerencia o ayuda para optimizar el cálculo de rebotes es más que bienvenida y agradecida!

---

## English

### Game details
A 2D Unity reimagining of the classic local 2-player Pong, focusing on software architecture best practices, data decoupling via ScriptableObjects, and strictly component-based collision handling.

### How to play
* **Player 1:** `W` / `S` (Up / Down) — `A` / `D` (Left / Right)
* **Player 2:** `Up Arrow` / `Down Arrow` — `Left Arrow` / `Right Arrow`

**Core Mechanics:**
* **Objective:** Defend your goal and score points by getting the ball past your opponent's paddle.
* **Progressive Acceleration:** Each paddle hit permanently increases ball velocity, raising the challenge as rallies lengthen.
* **Dynamic Bounces:** Top and bottom boundaries deflect the ball with subtle angle variations to prevent repetitive trajectories.
* **Power-Ups:** Deactivated; still a work in progress. Only a single GameObject appears in both sides for now, just to test the item pickup feedback.

### Settings & Options
The game includes a configuration panel backed by ScriptableObjects to customize the match in real-time:
* **Paddle Speed:** Independent sliders to fine-tune movement speeds separately for Player 1 and Player 2.
* **Color Customization:** Color pickers to personalize each paddle's visual tone according to player preferences.
* **Match Rules:** Adjustment of global match parameters: choose the number of points to score or the time allowed to score.

> **Note on ball physics:** Ball physics and bounce angles are not yet fully perfected and contain edge-case behaviors to polish (such as occasional grazing trajectories or corner paddle collisions).
>  This remains an open area for future improvement.
>  Any feedback, tips, or contributions to optimize bounce calculations are always deeply appreciated!

---

### Desarrollado Por / By
Agustin Lazaro Blanco Romero

### Créditos / Credits
* **Sprites / Arte**: [kenney_ui-pack-adventure](https://kenney.nl/assets/ui-pack-adventure)
* **Audio / SFX**: 
* **Fuentes**: [04b-30](https://www.dafont.com/es/04b-30.font)

