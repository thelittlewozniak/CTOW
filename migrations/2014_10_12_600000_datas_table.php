<?php

use Illuminate\Support\Facades\Schema;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Database\Migrations\Migration;

class DatasTable extends Migration
{
    /**
     * Run the migrations.
     *
     * @return void
     */
    public function up()
    {
        Schema::create('datas', function (Blueprint $table) {
            $table->increments('id_data');
            $table->string('value_data');
            $table->integer('type_data_id_type_data')->unsigned();
            $table->foreign('type_data_id_type_data')->references('id_type_data')->on('type_datas');
            $table->integer('device_guid')->unsigned();
            $table->foreign('device_guid')->references('guid')->on('devices');
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
        Schema::drop('datas');
    }
}