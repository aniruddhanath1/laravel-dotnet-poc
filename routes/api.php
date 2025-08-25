<?php

use Illuminate\Support\Facades\Route;
use App\Http\Controllers\Api\PatientController;
use App\Http\Controllers\Api\DoctorController;
use App\Http\Controllers\Api\SessionController;

Route::prefix('v1')->group(function () {
    // Public Auth endpoints
    Route::post('auth/register', [\App\Http\Controllers\AuthController::class, 'register']);
    Route::post('auth/login', [\App\Http\Controllers\AuthController::class, 'login']);

    // Protected API routes
    Route::middleware(['auth:api'])->group(function () {
        Route::apiResource('patients', PatientController::class);
        Route::apiResource('doctors', DoctorController::class);
        Route::post('sessions', [SessionController::class, 'store']);
        Route::delete('sessions', [SessionController::class, 'destroy']);
    });
});
