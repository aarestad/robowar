/* Tokens.h */
/* David Harris 1/19/91 */

#ifndef __ROBOWAR_TOKENS__
#define __ROBOWAR_TOKENS__ (1)

typedef enum { /* These are the tokens to be parsed */
	plus_ = 20000,
	minus_,
	times_,
	divide_,
	greater_,
	less_,
	equal_,
	notequal_,
} comparatorCommandCode;

typedef enum {
	store_ = 20100,
	drop_,		swap_,		roll_,		jump_,		call_,		dup_,
	if_,		ife_,		recall_,	end_,		nop_,		and_,
	or_,		eor_,		mod_,		beep_,		chs_,		not_,
	arctan_,	abs_,		sin_,		cos_,		tan_,		sqrt_,
	icon0_,		icon1_,		icon2_,		icon3_,		icon4_,		icon5_,
	icon6_,		icon7_,		icon8_,		icon9_,		printNum_,  sync_,
	vStore_,	vRecall_,	dist_,		ifg_,		ifeg_,		debug_,
	snd0_,		snd1_,		snd2_,		snd3_,		snd4_,		snd5_,
	snd6_,		snd7_,		snd8_,		snd9_,		inton_,		intoff_,
	rti_,		setint_,	setparam_,  mrb_,		dropall_,	flushint_,
	max_,		min_,		arccos_,	arcsin_
} operatorCommandCode;

typedef enum {		/* The robot variables */
	x_ = 23, y_,
	fire_ = 26,
	energy_,	shield_,	range_,		aim_,		speedx_,	speedy_,
	damage_,	random_,	missile_,   nuke_,		collision_, channel_,
	signal_,	movex_,		movey_,		joce_,		radar_,		look_,
	scan_,		chronon_,   hell_,		drone_,		mine_,		laser_,
	susie_,		robots_,	friend_,	bullet_,	doppler_,   stunner_,
	top_,		bottom_,	left_,		right_,		wall_,		teammates_,
	probe_,		history_,   id_,		kills_,		approach_,
	unknown_ = (-20000),
	null_ = (-20001)
} registerCommandCode;

#endif
