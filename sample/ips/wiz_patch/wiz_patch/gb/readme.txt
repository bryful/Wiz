* 未改造のROMイメージにパッチしてください *

■ 外伝I

[変更項目]
・+Cの修正
・武器以外の倍打も認識させる
・ヒーリング設定をHPに変更
・アイテムのクリティカルヒットを有効にする

● +C部分の修正, 武器以外の倍打認識, アイテムのクリティカルヒット認識

ROM2:6185 FA 82 C9         ld a,(c982)
ROM2:6188 A7               and a
ROM2:6189 20 19            jr nz,61a4		; 武器以外
;
; 武器
;
ROM2:618B FA 5E D1         ld a,(d15e)
ROM2:618E 57               ld d,a		; D = STR補正
ROM2:618F 21 9A C9         ld hl,c99a
ROM2:6192 01 5C D1         ld bc,d15c
ROM2:6195 2A               ldi a,(hl)
ROM2:6196 02               ld (bc),a
ROM2:6197 03               inc bc
ROM2:6198 2A               ldi a,(hl)
ROM2:6199 02               ld (bc),a
ROM2:619A 03               inc bc
ROM2:619B 7E               ld a,(hl)
ROM2:619C 82               add d
ROM2:619D 02               ld (bc),a		; +C部分
ROM2:619E FA A2 C9         ld a,(c9a2)
ROM2:61A1 EA 5F D1         ld (d15f),a
;
; 全アイテム共通
;
ROM2:61A4 21 5A D1         ld hl,d15a
ROM2:61A7 FA 84 C9         ld a,(c984)
ROM2:61AA E6 02            and a,02
ROM2:61AC CB 3F            srl a		; 1に修正
ROM2:61AE B6               or (hl)
ROM2:61AF 77               ld (hl),a		; 首
;
ROM2:61B0 11 9E C9         ld de,c99e
ROM2:61B3 21 66 D1         ld hl,d166
ROM2:61B6 1A               ld a,(de)
ROM2:61B7 13               inc de
ROM2:61B8 B6               or (hl)
ROM2:61B9 22               ldi (hl),a
ROM2:61BA 1A               ld a,(de)
ROM2:61BB B6               or (hl)
ROM2:61BC 77               ld (hl),a
ROM2:61BD 18 1C            jr 61db
ROM2:61BF 00               nop


● ヒーリングをLVからHP上昇に変更する

ROM4:4E4F 7E               ld a,(hl)
ROM4:4E50 FE 05            cp a,05
ROM4:4E52 30 40            jr nc,4e94		; 死亡以上
;
ROM4:4E54 3D               dec a
ROM4:4E55 20 04            jr nz,4e5b
ROM4:4E57 2E 05            ld l,05		;
ROM4:4E59 18 13            jr 4e6e		;
;
ROM4:4E5B 3D               dec a
ROM4:4E5C 20 04            jr nz,4e62
ROM4:4E5E 2E 08            ld l,08		;
ROM4:4E60 18 0C            jr 4e6e		;
;
ROM4:4E62 3D               dec a
ROM4:4E63 20 04            jr nz,4e69
ROM4:4E65 2E 02            ld l,02		;
ROM4:4E67 18 05            jr 4e6e		;
;
ROM4:4E69 3D               dec a
ROM4:4E6A 20 0E            jr nz,4e7a
ROM4:4E6C 2E 01            ld l,01
;
ROM4:4E6E CD 25 4F         call 4f25		;
;
ROM4:4E71 18 07            jr 4e7a		; (空き)
ROM4:4E73 00               nop			;
ROM4:4E74 00               nop			;
ROM4:4E75 00               nop			;
ROM4:4E76 00               nop			;
ROM4:4E77 00               nop			;
ROM4:4E78 00               nop			;
ROM4:4E79 00               nop			;
;
ROM4:4E7A 78               ld a,b
ROM4:4E7B CD C2 0F         call 0fc2
ROM4:4E7E 11 05 00         ld de,0005		; HPへのオフセット
ROM4:4E81 19               add hl,de		;

■ 外伝II

● ヒーリング関連の変更 ($010E85-$010EB2)


■ 外伝III

● ヒーリング関連の変更 ($01104A-$011077)