<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

class Szervizkonyv extends Migration
{
    /**
     * Run the migrations.
     *
     * @return void
     */
    public function up()
    {
        Schema::create('szervizkonyv', function (Blueprint $table) {
            $table->id();
            $table->string('tulajdonos', 50)->nullable();
            $table->integer('auto');
            $table->tinyInteger('garancialis');
            $table->integer('eletkor');
            $table->timestamp('szerviz_kezdete', 0)->nullable();
            $table->timestamp('szerviz_vege', 0)->nullable();
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
        Schema::dropIfExists('szervizkonvy');
    }
}
