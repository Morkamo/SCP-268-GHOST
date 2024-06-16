# SCP-268-GHOST
Плагин добавляет на ваш сервер новый "Custom Item"

При применении игрок может проходить сквозь двери и не триггерить "Тесла Ворота"

**Базовый config:**
```
SCP-268-GHOST:
  is_enabled: true
  debug: false
  item268_g:
    id: 1
    weight: 1
    name: 'SCP-268-GHOST'
    description: 'SCP-268-GHOST'
    spawn_properties:
      limit: 0
      dynamic_spawn_points: []
      static_spawn_points: []
      role_spawn_points: []
    type: SCP268
    scale:
      x: 1
      y: 1
      z: 1
```
