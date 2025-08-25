<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use App\Models\Patient;
use App\Models\Doctor;
use Illuminate\Support\Facades\Hash;
use Tymon\JWTAuth\Facades\JWTAuth;
use App\Http\Resources\PatientResource;
use App\Http\Resources\DoctorResource;

class AuthController extends Controller
{
    public function register(Request $request)
    {
        $request->validate([
            'type' => 'required|in:doctor,patient',
            'name' => 'required|string|max:255',
            'email' => 'required|email|unique:' . ($request->type === 'doctor' ? 'doctors' : 'patients') . ',email',
            'password' => 'required|string|min:6',
        ]);

        $data = $request->only('name', 'email');
        $data['password'] = Hash::make($request->password);

        if ($request->type === 'doctor') {
            $user = Doctor::create($data);
            $token = JWTAuth::fromUser($user);
            return response()->json([
                'token' => $token,
                'user' => new DoctorResource($user)
            ], 201);
        } else {
            $user = Patient::create($data);
            $token = JWTAuth::fromUser($user);
            return response()->json([
                'token' => $token,
                'user' => new PatientResource($user)
            ], 201);
        }
    }

    public function login(Request $request)
    {
        $request->validate([
            'type' => 'required|in:doctor,patient',
            'email' => 'required|email',
            'password' => 'required',
        ]);

        $user = $request->type === 'doctor'
            ? Doctor::where('email', $request->email)->first()
            : Patient::where('email', $request->email)->first();

        if ($user && Hash::check($request->password, $user->password)) {
            $token = JWTAuth::fromUser($user);
            $resource = $request->type === 'doctor' ? new DoctorResource($user) : new PatientResource($user);
            return response()->json(['token' => $token, 'user' => $resource], 200);
        }

        return response()->json(['message' => 'Invalid credentials'], 401);
    }
}
