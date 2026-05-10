# [TieSoundEditor](https://github.com/MikeG6521/TieSoundEditor)

Author: [Michael Gaisser](mailto:mjgaisser@gmail.com)  
![GitHub Release](https://img.shields.io/github/v/release/MikeG621/TieSoundEditor)
![GitHub Release Date](https://img.shields.io/github/release-date/MikeG621/TieSoundEditor)
![GitHub License](https://img.shields.io/github/license/MikeG621/TieSoundEditor)

This editor reads and writes the WAV files within the VOIC and BLAS resource
types found in TIE95 LFD files.

## Latest Release
#### v1.3 - 10 May 2026
- Sound properties for the selected resource are now shown.
- Text I/O in WAV headers have been replaced with int32 comparisons to mitigate Unicode issues [[Issue #1](https://github.com/MikeG621/TieSoundEditor/issues/1)].
- WAV decode now uses the function in LfdReader.

---
### Additional Information
#### Dependencies
- [Idmr.Common](https://github.com/MikeG621/Common)
- [Idmr.LfdReader](https://github.com/MikeG621/LfdReader)

#### WAV Guidelines

Filenames for WAV to be imported must match the name of the resource they are
replacing as shown in the list.  This is to prevent accidental overwrites.

Exported WAV files will be 8-bit mono, 11,025 Hz.

#### Usage

- Open the LFD you wish to search using the '...' button next to the LFD text
box. The VOIC and BLAS resources will be displayed to the right. Selecting a
sound effect in the list will automatically play the sound.

- To save a resource as WAV, ensure that "Export" is selected, choose your
source LFD, choose your sound, and then choose your save location. Click the
Save button to commit. It is highly recommended to not change the filename.

- To import a sound, ensure that "Import" is selected, choose the LFD and
resource to replace, and then choose the WAV file with the same name as the
resource you are replacing. Click the Save button to commit.

As always, backup your original files first.

---
### Version History
#### v1.2 - 07 Sep 2019
- Rebuilt using current LfdReader library, fixes a crash with VOIC resources

#### v1.1.1 - 29 Jul 2015
- Released under MPL 2.0

#### v1.1 - 18 Sep 2009
- Updates to WAV processing

#### v1.0 - 15 Dec 2007
- Release

---
#### Copyright Information
Copyright © 2007- Michael Gaisser
This program and related files are licensed under the Mozilla Public License.
See License.txt for the full text. If for some reason the license was not
distributed with this program, you can obtain the full text of the license at
http://mozilla.org/MPL/2.0/.

"Star Wars" and related items are trademarks of LucasFilm Ltd and
LucasArts Entertainment Co.

This software is provided "as is" without warranty of any kind; including that
the software is free of defects, merchantable, fit for a particular purpose or
non-infringing. See the full license text for more details.