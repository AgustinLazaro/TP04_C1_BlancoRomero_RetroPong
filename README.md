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
enfocada en buenas prácticas de arquitectura, desacoplamiento de configuraciones mediante ScriptableObjects y detección de colisiones basada en componentes.

### Cómo jugar
* **Jugador 1:** `W` / `S` (Arriba / Abajo) — `A` / `D` (Izquierda / Derecha)
* **Jugador 2:** `Flecha Arriba` / `Flecha Abajo` — `Flecha Izquierda` / `Flecha Derecha`

**Mecánicas principales:**
* **Objetivo:** Defender el arco propio y anotar en el campo rival logrando que la pelota cruce la línea de gol.
* **Aceleración progresiva:** Cada impacto de la pelota contra una paleta incrementa su velocidad, aumentando el dinamismo y la exigencia de los reflejos en peloteos largos.
* **Rebote dinámico:** Las paredes superior e inferior devuelven la pelota al campo con leves variaciones de ángulo para evitar trayectorias estáticas.
* **Obstáculos dinámicos:** Obstáculos periódicos que aparecen en posiciones alternadas mediante un sistema desacoplado de Object Pooling, agregando desvíos imprevistos a las jugadas.
* **Power-Ups (En desarrollo):** Actualmente en proceso de integración. Aparecen objetos en el campo para validar eventos de recolección y respuesta visual.

### Opciones y Configuración (Settings)
El juego cuenta con paneles de ajustes respaldados por ScriptableObjects que permiten personalizar la partida en tiempo real:

* **Ajustes de Gameplay:**
  * **Velocidad de las paletas:** Sliders individuales para calibrar la velocidad de desplazamiento del Jugador 1 y Jugador 2 de forma independiente.
  * **Personalización de color:** Selector visual para modificar el tono de cada paleta según la preferencia de los jugadores.
  * **Reglas de juego:** Ajuste de parámetros globales del partido (definir límite de puntos o tiempo total de juego).
* **Ajustes de Audio:** Controles deslizantes independientes para mezclar el volumen de la música de fondo y los efectos de sonido (SFX).
  
> **Nota sobre el movimiento de la pelota:** La física y los ángulos de rebote actuales aún no son perfectos
> y presentan comportamientos a pulir (como trayectorias rasantes ocasionales o choques en bordes de paleta), por lo que quedan pendientes de arreglo en futuras iteraciones.
> ¡Cualquier feedback, sugerencia o ayuda para optimizar el cálculo de rebotes es más que bienvenida y agradecida!

---

## English

### Game details
A 2D Unity reimagining of the classic local 2-player Pong, focusing on software architecture best practices, 
data decoupling via ScriptableObjects, and strictly component-based collision handling.

### How to play
* **Player 1:** `W` / `S` (Up / Down) — `A` / `D` (Left / Right)
* **Player 2:** `Up Arrow` / `Down Arrow` — `Left Arrow` / `Right Arrow`

**Core Mechanics:**
* **Objective:** Defend your goal and score points by getting the ball past your opponent's paddle.
* **Progressive Acceleration:** Each paddle hit permanently increases ball velocity, raising the challenge as rallies lengthen.
* **Dynamic Bounces:** Top and bottom boundaries deflect the ball with subtle angle variations to prevent repetitive trajectories.
* **Dynamic Obstacles:** Periodic obstacles spawn in alternating field positions using a decoupled Object Pooling system, adding unpredictable deflections to ongoing rallies.
* **Power-Ups (Work in Progress):** Currently under active development. Standalone pickup objects appear on the field to test item pickup events and visual feedback.

### Settings & Options
The game includes modular configuration panels backed by ScriptableObjects to customize the match in real-time:
* **Gameplay Settings:**
  * **Paddle Speed:** Independent sliders to fine-tune movement speeds separately for Player 1 and Player 2.
  * **Color Customization:** Color pickers to personalize each paddle's visual tone according to player preferences.
  * **Match Rules:** Global match parameter adjustments (choose target score or match duration).
* **Audio Settings:** Dedicated volume controls to independently balance background music and sound effects (SFX).

> **Note on ball physics:** Ball physics and bounce angles are not yet fully perfected and contain edge-case behaviors to polish
>  (such as occasional grazing trajectories or corner paddle collisions).
>  This remains an open area for future improvement. Any feedback, tips, or contributions to optimize bounce calculations are always deeply appreciated!

---

### Desarrollado Por / By
Agustin Lazaro Blanco Romero  
GitHub: [https://github.com/AgustinLazaro](https://github.com/AgustinLazaro)

### Créditos / Credits
* **UI Sprites:** [Kenney (UI Pack - Adventure)](https://kenney.nl/assets/ui-pack-adventure)
* **Power-Up Sprites:** Kenney (New Platformer Pack 1.1)
* **Música / Music:** Luca D'Alessandro (lucadialessandro)
* **Fuentes / Fonts:** [04b-30](https://www.dafont.com/es/04b-30.font)

