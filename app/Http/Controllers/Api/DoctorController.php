<?php


/**
 * @OA\Tag(
 *     name="Doctors",
 *     description="API Endpoints for Doctors"
 * )
 *
 * @OA\PathItem(path="/api/v1/doctors")
 */
namespace App\Http\Controllers\Api;

use App\Http\Controllers\Controller;
use Illuminate\Http\Request;
use App\Models\Doctor;
use App\Http\Requests\StoreDoctorRequest;
use App\Http\Resources\DoctorResource;

class DoctorController extends Controller
{
    /**
     * Display a listing of the resource.
     */
    /**
     * @OA\Get(
     *     path="/api/v1/doctors",
     *     tags={"Doctors"},
     *     summary="Get list of doctors",
     *     @OA\Response(response=200, description="OK")
     * )
     */
    public function index()
    {
        $doctors = Doctor::all();
        return DoctorResource::collection($doctors);
    }

    /**
     * Store a newly created resource in storage.
     */
    /**
     * @OA\Post(
     *     path="/api/v1/doctors",
     *     tags={"Doctors"},
     *     summary="Create a new doctor",
     *     @OA\RequestBody(required=true, @OA\MediaType(mediaType="application/json")),
     *     @OA\Response(response=201, description="Created")
     * )
     */
    public function store(StoreDoctorRequest $request)
    {
        $doctor = Doctor::create($request->validated());
        return new DoctorResource($doctor);
    }

    /**
     * Display the specified resource.
     */
    /**
     * @OA\Get(
     *     path="/api/v1/doctors/{id}",
     *     tags={"Doctors"},
     *     summary="Get a doctor by ID",
     *     @OA\Parameter(name="id", in="path", required=true, @OA\Schema(type="integer")),
     *     @OA\Response(response=200, description="OK")
     * )
     */
    public function show(string $id)
    {
        $doctor = Doctor::findOrFail($id);
        return new DoctorResource($doctor);
    }

    /**
     * Update the specified resource in storage.
     */
    /**
     * @OA\Put(
     *     path="/api/v1/doctors/{id}",
     *     tags={"Doctors"},
     *     summary="Update a doctor",
     *     @OA\Parameter(name="id", in="path", required=true, @OA\Schema(type="integer")),
     *     @OA\RequestBody(required=true, @OA\MediaType(mediaType="application/json")),
     *     @OA\Response(response=200, description="OK")
     * )
     */
    public function update(StoreDoctorRequest $request, string $id)
    {
        $doctor = Doctor::findOrFail($id);
        $doctor->update($request->validated());
        return new DoctorResource($doctor);
    }

    /**
     * Remove the specified resource from storage.
     */
    /**
     * @OA\Delete(
     *     path="/api/v1/doctors/{id}",
     *     tags={"Doctors"},
     *     summary="Delete a doctor",
     *     @OA\Parameter(name="id", in="path", required=true, @OA\Schema(type="integer")),
     *     @OA\Response(response=204, description="No Content")
     * )
     */
    public function destroy(string $id)
    {
        $doctor = Doctor::findOrFail($id);
        $doctor->delete();
        return response()->json(null, 204);
    }
}
