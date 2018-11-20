<?php

use Illuminate\Support\Facades\Schema;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Database\Migrations\Migration;

class CreateMatchHistoryTable extends Migration
{
    /**
     * Run the migrations.
     *
     * @return void
     */
    public function up()
    {
        Schema::create('match_history', function (Blueprint $table) {
            $table->increments('id');
            $table->unsigned('player_id');
            $table->unsigned('opponent_id')->nullable(); //this way if an opponent is removed from database the match history is kept intact
            $table->foreign('player_id')->references('id')->on('users')->onDelete('cascade');
            $table->foreign('opponent_id')->references('id')->on('users')->onDelete('set null');
            $table->string('result');     
            $table->timestamps();
        });
    }

    /**
     * Reverse the migrations.
     *
     * @return void
     */
    public function down()
    {
        Schema::dropIfExists('match_history');
    }
}
