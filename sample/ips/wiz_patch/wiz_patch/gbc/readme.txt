�� Wizardry (GBC)�pips�ł��B

[�C������]
�E���΂₳�o�O
�E�f�B�X�y���o�O

�� Wizardry PG

�� ���΂₳�o�O�C��	: 006EBF-006EF5
ROM1:6EAE CD 6B 27         call 276b
ROM1:6EB1 E5               push hl
ROM1:6EB2 FA A0 D1         ld a,(d1a0)
ROM1:6EB5 4F               ld c,a
ROM1:6EB6 06 00            ld b,00
ROM1:6EB8 21 43 D5         ld hl,d543
ROM1:6EBB 09               add hl,bc
ROM1:6EBC 7E               ld a,(hl)
ROM1:6EBD D1               pop de
ROM1:6EBE B7               or a
ROM1:6EBF 20 35            jr nz,6ef6	; -1�o�C�g
;
ROM1:6EC1 21 0F 00         ld hl,000f
ROM1:6EC4 19               add hl,de
ROM1:6EC5 5E               ld e,(hl)
ROM1:6EC6 16 00            ld d,00
ROM1:6EC8 21 89 71         ld hl,7189
ROM1:6ECB 19               add hl,de
ROM1:6ECC 5E               ld e,(hl)
ROM1:6ECD 3E 04            ld a,04
ROM1:6ECF CD 91 03         call 0391
ROM1:6ED2 83               add e
ROM1:6ED3 28 0C            jr z,6ee1	;(�C������: +2�o�C�g)
ROM1:6ED5 CB 7F            bit 7,a	;
ROM1:6ED7 20 08            jr nz,6ee1	;
ROM1:6ED9 FE 0B            cp a,0b	;
ROM1:6EDB 38 06            jr c,6ee3	;
ROM1:6EDD 3E 0A            ld a,0a	;
ROM1:6EDF 18 02            jr 6ee3	;
ROM1:6EE1 3E 01            ld a,01	;
;
ROM1:6EE3 21 58 D2         ld hl,d258
ROM1:6EE6 09               add hl,bc
ROM1:6EE7 77               ld (hl),a
ROM1:6EE8 FA 09 C1         ld a,(c109)
ROM1:6EEB 4F               ld c,a
ROM1:6EEC FA A0 D1         ld a,(d1a0)
ROM1:6EEF 3C               inc a
ROM1:6EF0 EA A0 D1         ld (d1a0),a
ROM1:6EF3 B9               cp c
ROM1:6EF4 20 B8            jr nz,6eae	; -1�o�C�g

�� �f�B�X�y���o�O�C��	: 010650-010651
ROM4:4650 00               nop		; (2�{�ɂ��Ȃ��Ă���)
ROM4:4651 00               nop		;

�� Wizardry LOL

�� ���΂₳�o�O�C��	: 0072FC-007332
�� �f�B�X�y���o�O�C��	: 010658-010659

�� Wizardry KOD

�� ���΂₳�o�O�C��	: 007162-007198
�� �f�B�X�y���o�O�C��	: 010650-010651