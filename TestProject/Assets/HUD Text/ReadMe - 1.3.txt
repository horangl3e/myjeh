--------------------------------------------------
              NGUI: HUD Text
 Copyright © 2012 Tasharen Entertainment
                Version 1.3
http://www.tasharen.com/forum/index.php?topic=997.0
            support@tasharen.com
--------------------------------------------------

Thank you for buying NGUI HUD Text!

Usage:
1. Attach the HUDText script to a game object underneath your UIRoot and set the font it should use.
2. To make it follow an object drawn with another camera, attach UIFollowTarget to the same object and set its target.
3. From code, use HUDText's Add() function to add new floating text entries.

You can also tweak the splines on the HUDText script, changing the motion of the text as you see fit.

Video: http://www.youtube.com/watch?v=diql3UP1KQM

----------------------------------------------
Example Usage:
----------------------------------------------

HUDText hudText = GetComponent<HUDText>();

// This will show damage of 123 in red, and the message will immediately start moving.
hudText.Add(-123f, Color.red, 0f);

// This will show "Hello World!" and make it stay on the screen for 1 second before moving
hudText.Add("Hello World!", Color.white, 1f);

----------------------------------------------
Importing the full (or free) version of NGUI
----------------------------------------------

The steps are the same as upgrading NGUI:

1. Start a new scene.
2. Delete the NGUI folder.
3. Import the new NGUI package.

----------------------------------------------

If you have any questions, suggestions, comments or feature requests, please
drop by the forums, found here: http://www.tasharen.com/forum/index.php?topic=997.0